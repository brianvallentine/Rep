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
           77  NUM-BILHETE                        PIC X(254).
           77  SEQ-CONTA-BANCARIA                 PIC X(254).
           77  COD-CPF-CNPJ-TERCEIRO              PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  IND-TP-PESSOA                      PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-BILHETE
SEQ-CONTA-BANCARIA
COD-CPF-CNPJ-TERCEIRO
    COD-USUARIO
  IND-TP-PESSOA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO SEGUROS.VA_PAGTO_REST_TERCEIRO(NUM_BILHETE, SEQ_CONTA_BANCARIA, COD_CPF_CNPJ_TERCEIRO, COD_USUARIO, DTH_CADASTRAMENTO, IND_TP_PESSOA) VALUES (:NUM_BILHETE, :SEQ_CONTA_BANCARIA, :COD_CPF_CNPJ_TERCEIRO, :COD_USUARIO, CURRENT TIMESTAMP, :IND_TP_PESSOA) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
