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
           77  NUM-ENDOSSO                        PIC X(254).
           77  NUM-PARCELA                        PIC X(254).
           77  DATA-MOVIMENTO                     PIC X(254).
           77  DATA-VENCIMENTO                    PIC X(254).
           77  PREMIO-TOTAL-PAGO                  PIC X(254).
           77  PREMIO-TOTAL-DEV                   PIC X(254).
           77  QTD-DIAS-COBERTOS                  PIC X(254).
           77  DATA-FIM-VIG-PROP                  PIC X(254).
           77  DATA-CANCELAMENTO                  PIC X(254).
           77  IDTAB-SITUACAO                     PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  TIMESTAMP                          PIC X(254).
           77  DATA-MALA-VIG-PROP                 PIC X(254).
           77  DATA-MALA-CANCEL                   PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
    NUM-ENDOSSO
    NUM-PARCELA
 DATA-MOVIMENTO
DATA-VENCIMENTO
PREMIO-TOTAL-PAGO
PREMIO-TOTAL-DEV
QTD-DIAS-COBERTOS
DATA-FIM-VIG-PROP
DATA-CANCELAMENTO
 IDTAB-SITUACAO
       SITUACAO
      TIMESTAMP
DATA-MALA-VIG-PROP
DATA-MALA-CANCEL.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DATA_MOVIMENTO, DATA_VENCIMENTO, PREMIO_TOTAL_PAGO, PREMIO_TOTAL_DEV, QTD_DIAS_COBERTOS, DATA_FIM_VIG_PROP, DATA_CANCELAMENTO, IDTAB_SITUACAO, SITUACAO, TIMESTAMP, value(DATA_MALA_VIG_PROP, date('0001-01-01')), value(DATA_MALA_CANCEL, date('0001-01-01')) FROM seguros.cb_apolice_vigprop WHERE num_apolice = :NUM_APOLICE END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
