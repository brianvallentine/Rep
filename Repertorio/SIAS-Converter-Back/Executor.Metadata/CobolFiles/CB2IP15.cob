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
           77  CODUNIMO                           PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  NOMEUNIM                           PIC X(254).
           77  VALCPR                             PIC X(254).
           77  VLCRUZAD                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
       CODUNIMO
       DTINIVIG
       DTTERVIG
       NOMEUNIM
         VALCPR
       VLCRUZAD.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT CODUNIMO, NOMEUNIM, VALCPR, VLCRUZADDTINIVIG
               FROM seguros.v1moeda
               where
                 codunimo  = :CODUNIMO  and
                 dtinivig <= :DTINIVIG  and
                 dttervig >= :DTTERVIG
                END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
