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
           77  VALOR-EDI                          PIC X(254).
           77  VALOR-USS                          PIC X(254).
           77  VLEQPVNDA                          PIC X(254).
           77  VLDESPADM                          PIC X(254).
           77  OUTRDEBIT                          PIC X(254).
           77  OUTRCREDT                          PIC X(254).
           77  CONGENER                           PIC X(254).
           77  DTMOVTO-AC                         PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
      VALOR-EDI
      VALOR-USS
      VLEQPVNDA
      VLDESPADM
      OUTRDEBIT
      OUTRCREDT
       CONGENER
     DTMOVTO-AC.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR UPDATE seguros.v0cosced_cheque T1 SET VALOR_EDI = :VALOR_EDI, VALOR_USS = :VALOR_USS, VLEQPVNDA = :VLEQPVNDA, VLDESPADM = :VLDESPADM, OUTRDEBIT = :OUTRDEBIT, OUTRCREDT = :OUTRCREDT WHERE congener = :CONGENER AND dtmovto_ac = :DTMOVTO_AC END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
