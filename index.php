<?php
    /*url => http://localhost/Web_build/index.php */

    header("Access-Control-Allow-Origin: *");
    
    $arqName = $_POST['GAME']. "_Log".".csv";
    unset($_POST['GAME']); 
    $newData = $_POST;

    $arq;
    $arq = glob("./" . $arqName); //retorna um array com todos os arquivos q contem o nome especificado
    
    $arq = fopen($arqName, "a");

    fputcsv($arq, $newData);
    fclose($arq);
     
?>
