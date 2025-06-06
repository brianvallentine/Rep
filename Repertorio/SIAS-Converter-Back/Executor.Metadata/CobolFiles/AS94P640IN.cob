       IDENTIFICATION DIVISION.                                                 
       PROGRAM-ID. AC10P013.                                                    
                                                                                
      *---------------------*                                                   
       ENVIRONMENT DIVISION.                                                    
      *---------------------*                                                   
                                                                                
      *---------------------*                                                   
       CONFIGURATION SECTION.                                                   
      *---------------------*                                                   
                                                                                
      *-------------*                                                           
       SPECIAL-NAMES.                                                           
      *-------------*                                                           
           DECIMAL-POINT IS COMMA.                                              
                                                                                
      *--------------------*                                                    
       INPUT-OUTPUT SECTION.                                                    
      *--------------------*                                                    
                                                                                
      *-------------*                                                           
       DATA DIVISION.                                                           
      *-------------*                                                           
      *                                                                         
      *-----------------------*                                                 
       WORKING-STORAGE SECTION.                                                 
      *-----------------------*                                                 
             
      *----------------------------------------------------------------*        
      *- VARIAVEIS AUXILIARES                                          *        
      *----------------------------------------------------------------*        
                                                                                     
      *>    05  LK-TIP-CALC                        PIC 9(001) VALUE ZEROS .            
      *>    05  LK-NUM-APOL                        PIC 9(001) VALUE ZEROS .           
      *>    05  LK-NRENDOS                         PIC 9(001) VALUE ZEROS .   
      *>    05  LK-DTINIVIG                     OCCURS      2000   TIMES               
      *>                                        INDEXED      BY    WIND.          
      *>        10      WTABG-CODPRODU             PIC S9(004)        COMP.               
      *>            15  WTABG-OCORRETIP         OCCURS       003   TIMES       
      *>                                        INDEXED      BY    WIND2.     
      *>                25    WTABG-TIPO  PIC  X(001).                 

      *>   77  LK-TIP-CALC                        PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  COD-APLICACAO                      PIC X(254).
           77  TIPO-AUTORIZACAO                   PIC X(254).
           77  IFNULL(CHAR(MAX(TIMESTAMP)), ' ')  PIC X(254).
           77  IFNULL(SUBSTR(CHAR(MAX(TIMESTAMP)), 9, 2) || '/' || SUBSTR(CHAR(MAX(TIMESTAMP)), 6, 2) || '/' || SUBSTR(CHAR(MAX(TIMESTAMP)), 1, 4), ' ')PIC X(254).
           77  SUBSTR(CHAR(CURRENT DATE), 9, 2) || '/' || SUBSTR(CHAR(CURRENT DATE), 6, 2) || '/' || SUBSTR(CHAR(CURRENT DATE), 1, 4)PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    COD-USUARIO
  COD-APLICACAO
TIPO-AUTORIZACAO
IFNULL(CHAR(MAX(TIMESTAMP)), ' ')
IFNULL(SUBSTR(CHAR(MAX(TIMESTAMP)), 9, 2) || '/' || SUBSTR(CHAR(MAX(TIMESTAMP)), 6, 2) || '/' || SUBSTR(CHAR(MAX(TIMESTAMP)), 1, 4), ' ')
SUBSTR(CHAR(CURRENT DATE), 9, 2) || '/' || SUBSTR(CHAR(CURRENT DATE), 6, 2) || '/' || SUBSTR(CHAR(CURRENT DATE), 1, 4).

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT IFNULL(CHAR(MAX(TIMESTAMP)), ' '), IFNULL(SUBSTR(CHAR(MAX(TIMESTAMP)), 9, 2) 
               
                '/' 
               
                SUBSTR(CHAR(MAX(TIMESTAMP)), 6, 2) 
               
                '/' 
               
                SUBSTR(CHAR(MAX(TIMESTAMP)), 1, 4), ' '), SUBSTR(CHAR(CURRENT DATE), 9, 2) 
               
                '/' 
               
                SUBSTR(CHAR(CURRENT DATE), 6, 2) 
               
                '/' 
               
                SUBSTR(CHAR(CURRENT DATE), 1, 4) FROM seguros.log_autorizacao WHERE COD_USUARIO = :COD_USUARIO AND COD_APLICACAO = :COD_APLICACAO AND TIPO_AUTORIZACAO = :TIPO_AUTORIZACAO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
