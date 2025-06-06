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
           77  FONTE                              PIC X(254).
           77  NRPROPOS                           PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  DATOPR                             PIC X(254).
           77  HORAOPER                           PIC X(254).
           77  OCORHIST                           PIC X(254).
           77  CODUSU                             PIC X(254).
           77  COD-EMPRESA                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
          FONTE
       NRPROPOS
       OPERACAO
         DATOPR
       HORAOPER
       OCORHIST
         CODUSU
    COD-EMPRESA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0acomprop (FONTE, NRPROPOS, OPERACAO, DATOPR, HORAOPER, OCORHIST, CODUSU, COD_EMPRESA, TIMESTAMP) VALUES (:FONTE, :NRPROPOS, :OPERACAO, :DATOPR, :HORAOPER, :OCORHIST, :CODUSU, :COD_EMPRESA, CURRENT TIMESTAMP) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
