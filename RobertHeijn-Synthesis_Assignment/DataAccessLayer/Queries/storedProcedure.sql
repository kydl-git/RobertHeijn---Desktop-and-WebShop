
/*    This is my stored procedure filter_products() with which I want to filter
    products based on category name, subcategory name, min & max price or a 
    combination of all of them. It can also retrieve the product(s) which has 
    the highest price among either all products or sets of products 
    filtered based on category name and/or subcategory name. In case that more 
    then 1 product have the price equal to max(price) then it will retrieve all.    */
    
    /*   Because mysql does not have optional parameters when calling a 
         stored procedure(did not find anything in documentation to help me 
         with it), all 5 parameters have to be supplied whenever the 
         procedure is called.  */

DELIMITER $$
CREATE PROCEDURE filter_products(
    IN p_category VARCHAR(50) ,
    IN p_subcategory VARCHAR(50) ,
    IN p_min_price DECIMAL(10,2),
    IN p_max_price DECIMAL(10,2),
    IN p_get_highest_price TINYINT(1)
)
BEGIN
    SET @sql = NULL;

    SET @sql = CONCAT("SELECT i.id inventoryId, i.product_id, i.amount, p
    .name, p
    .subcategory_id, c.name SubCategory,rc.id CategId, rc.name Category, p.price, p.quantity, p.unit_id, u.name Unit 
    FROM rh_inventory_product i 
    LEFT JOIN rh_product p ON i.product_id = p.id 
    INNER JOIN rh_category c ON c.id = p.subcategory_id 
    INNER JOIN rh_unit u ON u.id = p.unit_id 
    INNER JOIN rh_category rc ON rc.id = c.parent_id WHERE 1=1 ");
    /*If p_get_highest_price is true, then filtering by min and max price is 
      not done no matter the values set for those 2. If category and subcategory 
      names have values then the query is adjusted accordingly.*/
    IF p_get_highest_price THEN
        SET @sql = CONCAT(@sql, " AND p.price = (SELECT MAX(rp.price) FROM 
        rh_product rp INNER JOIN rh_category rhc ON rhc.id = rp.subcategory_id 
        INNER JOIN rh_category arc ON arc.id = rhc.parent_id WHERE 1=1 ");
        IF (p_category IS NOT NULL AND p_category != '') THEN
            SET @sql = CONCAT(@sql, " AND SOUNDEX(arc.name) = SOUNDEX('", p_category,"')");
        END IF;
        IF (p_subcategory IS NOT NULL AND p_subcategory != '') THEN
            IF (p_category IS NOT NULL AND p_category != '') THEN
                SET @sql = CONCAT(@sql, " OR SOUNDEX(rhc.name) = SOUNDEX('", p_subcategory, "'))");
                SET @sql = CONCAT(@sql, " AND (SOUNDEX(rc.name) = SOUNDEX('", p_category, "')");
                SET @sql = CONCAT(@sql, " OR SOUNDEX(c.name) = SOUNDEX('", p_subcategory, "'))");
            ELSE
                SET @sql = CONCAT(@sql, " AND SOUNDEX(rhc.name) = SOUNDEX('", p_subcategory, "'))");
                SET @sql = CONCAT(@sql, " AND SOUNDEX(c.name) = SOUNDEX('", p_subcategory, "')");
            END IF;
        ELSE
            SET @sql = CONCAT(@sql, ") ORDER BY i.id");
        END IF;
    ELSE
        /* If p_get_highest_price is false, then the following query is concatenated to the initial one.*/
        IF (p_category IS NOT NULL AND p_category != '') THEN
            SET @sql = CONCAT(@sql, " AND (SOUNDEX(rc.name) = SOUNDEX('", 
                p_category, "')");
            IF (p_subcategory IS NULL OR p_subcategory = '') THEN
                SET @sql = CONCAT(@sql, ")");
            END IF;
        END IF;

        IF (p_subcategory IS NOT NULL AND p_subcategory != '') THEN
            IF (p_category IS NOT NULL AND p_category != '') THEN
                SET @sql = CONCAT(@sql, " OR SOUNDEX(c.name) = SOUNDEX('",p_subcategory, "'))");
            ELSE
                SET @sql = CONCAT(@sql, " AND SOUNDEX(c.name) = SOUNDEX('", p_subcategory, "')");
            END IF;
        END IF;

        IF (p_min_price <> 0 AND p_min_price IS NOT NULL) THEN
            SET @sql = CONCAT(@sql, " AND p.price >= ", p_min_price );
        END IF;

        IF (p_max_price <> 0 AND p_max_price IS NOT NULL) THEN
            SET @sql = CONCAT(@sql, " AND p.price <= ", p_max_price);
        END IF;
        SET @sql = CONCAT(@sql, " ORDER BY i.id");
    END IF;

    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END$$
DELIMITER ;