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
           77  AS00W02                            PIC X(254).
           77  AS00W02                            PIC X(254).
           77  AS00W02                            PIC X(254).
           77  AS00W02                            PIC X(254).
           77  AS00W02                            PIC X(254).
           77  AS00W02                            PIC X(254).
           77  NOMGRU                             PIC X(254).
           77  SITUACAO                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
        AS00W02
        AS00W02
        AS00W02
        AS00W02
        AS00W02
        AS00W02
         NOMGRU
       SITUACAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT NOMGRUSITUACAO
               FROM seguros.v1estrutur
               where codsis=:AS00W02.CODSIS and
                     subsis=:AS00W02.SUBSIS and
                     codgru=:AS00W02.CODGRU and
                     subgru=:AS00W02.SUBGRU and
                     codite=:AS00W02.CODITE and
                     subite=:AS00W02.SUBITE
                END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
