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
           77  DAC-PARCELA                        PIC X(254).
           77  DATA-MOVIMENTO                     PIC X(254).
           77  COD-OPERACAO                       PIC X(254).
           77  HORA-OPERACAO                      PIC X(254).
           77  OCORR-HISTORICO                    PIC X(254).
           77  PRM-TARIFARIO                      PIC X(254).
           77  VAL-DESCONTO                       PIC X(254).
           77  PRM-LIQUIDO                        PIC X(254).
           77  ADICIONAL-FRACIO                   PIC X(254).
           77  VAL-CUSTO-EMISSAO                  PIC X(254).
           77  VAL-IOCC                           PIC X(254).
           77  PRM-TOTAL                          PIC X(254).
           77  VAL-OPERACAO                       PIC X(254).
           77  DATA-VENCIMENTO                    PIC X(254).
           77  BCO-COBRANCA                       PIC X(254).
           77  AGE-COBRANCA                       PIC X(254).
           77  NUM-AVISO-CREDITO                  PIC X(254).
           77  ENDOS-CANCELA                      PIC X(254).
           77  SIT-CONTABIL                       PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  RENUM-DOCUMENTO                    PIC X(254).
           77  DATA-QUITACAO                      PIC X(254).
           77  COD-EMPRESA                        PIC X(254).
           77  TIMESTAMP                          PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
    NUM-ENDOSSO
    NUM-PARCELA
    DAC-PARCELA
 DATA-MOVIMENTO
   COD-OPERACAO
  HORA-OPERACAO
OCORR-HISTORICO
  PRM-TARIFARIO
   VAL-DESCONTO
    PRM-LIQUIDO
ADICIONAL-FRACIO
VAL-CUSTO-EMISSAO
       VAL-IOCC
      PRM-TOTAL
   VAL-OPERACAO
DATA-VENCIMENTO
   BCO-COBRANCA
   AGE-COBRANCA
NUM-AVISO-CREDITO
  ENDOS-CANCELA
   SIT-CONTABIL
    COD-USUARIO
RENUM-DOCUMENTO
  DATA-QUITACAO
    COD-EMPRESA
      TIMESTAMP.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DAC_PARCELA, DATA_MOVIMENTO, COD_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, PRM_TARIFARIO, VAL_DESCONTO, PRM_LIQUIDO, ADICIONAL_FRACIO, VAL_CUSTO_EMISSAO, VAL_IOCC, PRM_TOTAL, VAL_OPERACAO, DATA_VENCIMENTO, BCO_COBRANCA, AGE_COBRANCA, NUM_AVISO_CREDITO, ENDOS_CANCELA, SIT_CONTABIL, COD_USUARIO, RENUM_DOCUMENTO, DATA_QUITACAO, COD_EMPRESA, TIMESTAMP FROM seguros.parcela_historico WHERE T1.NUM_APOLICE = :NUM_APOLICE AND T1.NUM_ENDOSSO = :NUM_ENDOSSO AND T1.NUM_PARCELA = :NUM_PARCELA AND T1.OCORR_HISTORICO = (SELECT MAX(T2.OCORR_HISTORICO) FROM SEGUROS.seguros.parcela_historico T2 WHERE T2.NUM_APOLICE = :NUM_APOLICE AND T2.NUM_ENDOSSO = :NUM_ENDOSSO AND T2.NUM_PARCELA = :NUM_PARCELA) WITH UR END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
