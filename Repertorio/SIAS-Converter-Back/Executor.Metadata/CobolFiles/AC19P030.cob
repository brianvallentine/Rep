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
           77  CODUSU                             PIC X(254).
           77  DATA-SOLICITACAO                   PIC X(254).
           77  IDSISTEM                           PIC X(254).
           77  PERI-INICIAL                       PIC X(254).
           77  PERI-FINAL                         PIC X(254).
           77  DATA-REFERENCIA                    PIC X(254).
           77  CONGENER                           PIC X(254).
           77  CODUNIMO                           PIC X(254).
           77  CORRECAO                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
         CODUSU
DATA-SOLICITACAO
       IDSISTEM
   PERI-INICIAL
     PERI-FINAL
DATA-REFERENCIA
       CONGENER
       CODUNIMO
       CORRECAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0relatorios (CODUSU, DATA_SOLICITACAO, IDSISTEM, CODRELAT, NRCOPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO, FONTE, CODPDT, RAMO, MODALIDA, CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, NRCERTIF, NRTIT, CODSUBES, OPERACAO, COD_PLANO, OCORHIST, APOLIDER, ENDOSLID, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, CODUNIMO, CORRECAO, SITUACAO, PREVIA_DEFINITIVA, ANAL_RESUMO, cod_empresa, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) VALUES (:CODUSU, :DATA_SOLICITACAO, :IDSISTEM, :CODRELAT, 0, 0, :PERI_INICIAL, :PERI_FINAL, :DATA_REFERENCIA, 0, 0, 0, 0, 0, 0, 0, :CONGENER, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ', ' ', 0, 0, ' ', 0, :CODUNIMO, :CORRECAO, ' ', ' ', ' ', 0, 0, 0, current timestamp) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
