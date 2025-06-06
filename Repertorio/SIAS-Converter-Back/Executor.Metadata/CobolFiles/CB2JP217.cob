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
           77  DATA-SOLICITACAO                   PIC X(254).
           77  IDSISTEM                           PIC X(254).
           77  PERI-INICIAL                       PIC X(254).
           77  PERI-FINAL                         PIC X(254).
           77  DATA-REFERENCIA                    PIC X(254).
           77  ORGAO                              PIC X(254).
           77  FONTE                              PIC X(254).
           77  RAMO                               PIC X(254).
           77  CONGENER                           PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  CODRELAT                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
DATA-SOLICITACAO
       IDSISTEM
   PERI-INICIAL
     PERI-FINAL
DATA-REFERENCIA
          ORGAO
          FONTE
           RAMO
       CONGENER
    NUM-APOLICE
        NRENDOS
       NRPARCEL
       SITUACAO
       CODRELAT.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT CODRELAT
               FROM seguros.v1relatorios
               WHERE 
               WHERE    DATA_SOLICITACAO   =   :DATA_SOLICITACAO
                    AND     IDSISTEM                     =   :IDSISTEM
                    AND     CODRELAT   BETWEEN   'CV0120B1'   AND   'CV0120B9'
                    AND     PERI_INICIAL               =   :PERI_INICIAL
                    AND     PERI_FINAL                 =   :PERI_FINAL
                    AND     DATA_REFERENCIA   =   :DATA_REFERENCIA    
                    AND     ORGAO                         =   :ORGAO
                    AND     FONTE                          =   :FONTE    
                    AND     RAMO                           =   :RAMO  
                    AND     CONGENER                 =   :CONGENER
                    AND     NUM_APOLICE             =  :NUM_APOLICE
                    AND     NRENDOS                    =  :NRENDOS
                    AND     NRPARCEL                   =  :NRPARCEL 
                    AND     SITUACAO                    =  :SITUACAO
               ORDER BY END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
