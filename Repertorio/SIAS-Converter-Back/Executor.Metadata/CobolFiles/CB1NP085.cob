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
           77  BCOAVISO                           PIC X(254).
           77  AGEAVISO                           PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  FONTE                              PIC X(254).
           77  NRRCAP                             PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  VLRCAP                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
       BCOAVISO
       AGEAVISO
        NRAVISO
          FONTE
         NRRCAP
       OPERACAO
        DTMOVTO
         VLRCAP.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT FONTE, NRRCAP, OPERACAO, DTMOVTO, VLRCAP FROM seguros.v1rcapcomp WHERE bcoaviso = :BCOAVISO AND ageaviso = :AGEAVISO AND nraviso = :NRAVISO AND situacao = '0' END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
