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
           77  DATA-VENC-CONTR                    PIC X(254).
           77  IDTAB-SITUACAO                     PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  NUM-TITULO                         PIC X(254).
           77  DATA-VENCIMENTO                    PIC X(254).
           77  DTA-VENCIMENTO-AR                  PIC X(254).
           77  PREMIO-TOTAL                       PIC X(254).
           77  VALOR-ACRESCIMO                    PIC X(254).
           77  VALOR-TARIFA                       PIC X(254).
           77  VALOR-VISTORIA                     PIC X(254).
           77  DATA-ENVIO                         PIC X(254).
           77  TIMESTAMP                          PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
    NUM-ENDOSSO
    NUM-PARCELA
 DATA-MOVIMENTO
DATA-VENC-CONTR
 IDTAB-SITUACAO
       SITUACAO
     NUM-TITULO
DATA-VENCIMENTO
DTA-VENCIMENTO-AR
   PREMIO-TOTAL
VALOR-ACRESCIMO
   VALOR-TARIFA
 VALOR-VISTORIA
     DATA-ENVIO
      TIMESTAMP.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DATA_MOVIMENTO, DATA_VENC_CONTR, IDTAB_SITUACAO, SITUACAO, VALUE(NUM_TITULO,0), VALUE(DATA_VENCIMENTO,DATE('0001-01-01')), VALUE(DTA_VENCIMENTO_AR,DATE('0001-01-01')), VALUE(PREMIO_TOTAL,0), VALUE(VALOR_ACRESCIMO,0), VALUE(VALOR_TARIFA,0), VALUE(VALOR_VISTORIA,0), VALUE(DATA_ENVIO,DATE('0001-01-01')), TIMESTAMP FROM seguros.cb_mala_parcatraso WHERE NUM_APOLICE = :NUM_APOLICE AND NUM_ENDOSSO = :NUM_ENDOSSO AND NUM_PARCELA = :NUM_PARCELA ORDER BY DATA_MOVIMENTO DESC END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
