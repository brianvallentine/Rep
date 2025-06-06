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
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NUM-ITEM                           PIC X(254).
           77  RAMOFR                             PIC X(254).
           77  MODALIFR                           PIC X(254).
           77  COD-COBERTURA                      PIC X(254).
           77  PCT-COBERTURA                      PIC X(254).
           77  DATA-INIVIGENCIA                   PIC X(254).
           77  DATA-TERVIGENCIA                   PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       NUM-ITEM
         RAMOFR
       MODALIFR
  COD-COBERTURA
  PCT-COBERTURA
DATA-INIVIGENCIA
DATA-TERVIGENCIA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NRENDOS, NUM_ITEM, RAMOFR, MODALIFR, COD_COBERTURA, PCT_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA FROM seguros.v1coberapol WHERE num_apolice = :NUM_APOLICE AND nrendos = :NRENDOS AND num_item = 0 AND cod_cobertura = 0 ORDER BY num_apolice, nrendos, ramofr, modalifr END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
