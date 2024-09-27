------ Declarations
DECLARE
    -- Define strings
    num1 VARCHAR2(200) := '234324324324324234324324324234324324432423432432432432432432432432432432423432432432432432432432432423432432432423432432432432423432';
    num2 VARCHAR2(200) := '987987987987987987987987987987987987978798798789789797897979789879797979879797979789797979797979879789789879879879797898797979798798';
    
    -- Get length of numbers
    len1 NUMBER := LENGTH(num1);
    len2 NUMBER := LENGTH(num2);
    
    -- Declare array
    result_array DBMS_SQL.NUMBER_TABLE;
    
    -- Loop counters + variables
    i NUMBER;
    j NUMBER;
    mul NUMBER;
    sum NUMBER;
    carry NUMBER;
    
    -- Declare final result string
    result_str VARCHAR2(500) := '';
BEGIN
    -- Initialize result array w/ zeros
    FOR i IN 1..(len1 + len2) LOOP
        result_array(i) := 0;
    END LOOP;

    -- Multiply digit of num1 by digit of num2
    FOR i IN REVERSE 1..len1 LOOP
        FOR j IN REVERSE 1..len2 LOOP
            mul := TO_NUMBER(SUBSTR(num1, i, 1)) * TO_NUMBER(SUBSTR(num2, j, 1));
            sum := mul + result_array(i + j);
            result_array(i + j) := sum MOD 10;
            result_array(i + j - 1) := result_array(i + j - 1) + TRUNC(sum / 10);
        END LOOP;
    END LOOP;

    -- Convert result array to string
    FOR i IN 1..(len1 + len2) LOOP
        IF NOT (result_str IS NULL AND result_array(i) = 0) THEN
            result_str := result_str || TO_CHAR(result_array(i));
        END IF;
    END LOOP;

    -- Null handler
    IF result_str IS NULL THEN
        result_str := '0';
    END IF;

    -- Output result
    DBMS_OUTPUT.PUT_LINE(result_str);
END;
/
