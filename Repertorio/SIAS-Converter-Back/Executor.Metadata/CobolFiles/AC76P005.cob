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
           77  RAMOFR                             PIC X(254).
           77  MODALIFR                           PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  CODCORR                            PIC X(254).
           77  CODSUBES                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  PCPARCOR                           PIC X(254).
           77  PCCOMCOR                           PIC X(254).
           77  TIPCOM                             PIC X(254).
           77  INDCRT                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
         RAMOFR
       MODALIFR
       DTINIVIG
        CODCORR
       CODSUBES
       DTTERVIG
       PCPARCOR
       PCCOMCOR
         TIPCOM
         INDCRT.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, RAMOFR, MODALIFR, CODCORR, CODSUBES, DTINIVIG, DTTERVIG, PCPARCOR, PCCOMCOR, TIPCOM, INDCRT FROM seguros.v1apolcorret WHERE num_apolice = :NUM_APOLICE AND ramofr = :RAMOFR AND modalifr = :MODALIFR AND dtinivig <= :DTINIVIG AND dttervig >= :DTINIVIG END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
