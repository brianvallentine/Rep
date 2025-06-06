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
           77  NRRCAP                             PIC X(254).
           77  NRRCAPCO                           PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  HORAOPER                           PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  BCOAVISO                           PIC X(254).
           77  AGEAVISO                           PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  VLRCAP                             PIC X(254).
           77  DATARCAP                           PIC X(254).
           77  DTCADAST                           PIC X(254).
           77  SITCONTB                           PIC X(254).
           77  dtmovto                            PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
          FONTE
         NRRCAP
       NRRCAPCO
       OPERACAO
       HORAOPER
       SITUACAO
       BCOAVISO
       AGEAVISO
        NRAVISO
         VLRCAP
       DATARCAP
       DTCADAST
       SITCONTB
        dtmovto.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT FONTE, NRRCAP, NRRCAPCO, OPERACAO, HORAOPER, SITUACAO, BCOAVISO, AGEAVISO, NRAVISO, VLRCAP, DATARCAP, DTCADAST, SITCONTB, dtmovto FROM seguros.v1rcapcomp WHERE fonte = :FONTE AND nrrcap = :NRRCAP AND operacao IN (200, 220) AND situacao = '0' END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
