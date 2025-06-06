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
           77  NUM-PROPOSTA                       PIC X(254).
           77  NUM-CERTIFICADO                    PIC X(254).
           77  NUM-PARCELA                        PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NUM-ENDOSSO                        PIC X(254).
           77  SEQ-CONTROLE-SIGCB                 PIC X(254).
           77  NUM-OCORR-MOVTO                    PIC X(254).
           77  NUM-IDLG                           PIC X(254).
           77  COD-PRODUTO                        PIC X(254).
           77  DTA-MOVIMENTO                      PIC X(254).
           77  DTA-VENCIMENTO                     PIC X(254).
           77  VLR-PREMIO-TOTAL                   PIC X(254).
           77  VLR-IOF                            PIC X(254).
           77  QTD-PARCELA                        PIC X(254).
           77  QTD-DIAS-CUSTODIA                  PIC X(254).
           77  COD-CLIENTE                        PIC X(254).
           77  COD-CEDENTE-SAP                    PIC X(254).
           77  NUM-BOLETO-INTERNO                 PIC X(254).
           77  NUM-NOSSO-NUMERO-SAP               PIC X(254).
           77  COD-LINHA-DIGITAVEL                PIC X(254).
           77  NUM-TITULO                         PIC X(254).
           77  IDE-SISTEMA                        PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  COD-SITUACAO                       PIC X(254).
           77  DTH-PROCESSAMENTO                  PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
   NUM-PROPOSTA
NUM-CERTIFICADO
    NUM-PARCELA
    NUM-APOLICE
    NUM-ENDOSSO
SEQ-CONTROLE-SIGCB
NUM-OCORR-MOVTO
       NUM-IDLG
    COD-PRODUTO
  DTA-MOVIMENTO
 DTA-VENCIMENTO
VLR-PREMIO-TOTAL
        VLR-IOF
    QTD-PARCELA
QTD-DIAS-CUSTODIA
    COD-CLIENTE
COD-CEDENTE-SAP
NUM-BOLETO-INTERNO
NUM-NOSSO-NUMERO-SAP
COD-LINHA-DIGITAVEL
     NUM-TITULO
    IDE-SISTEMA
    COD-USUARIO
   COD-SITUACAO
DTH-PROCESSAMENTO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT NUM_PROPOSTA, NUM_CERTIFICADO, NUM_PARCELA, NUM_APOLICE, NUM_ENDOSSO, SEQ_CONTROLE_SIGCB, NUM_OCORR_MOVTO, NUM_IDLG, COD_PRODUTO, DTA_MOVIMENTO, DTA_VENCIMENTO, VLR_PREMIO_TOTAL, VLR_IOF, QTD_PARCELA, QTD_DIAS_CUSTODIA, COD_CLIENTE, COD_CEDENTE_SAP, NUM_BOLETO_INTERNO, NUM_NOSSO_NUMERO_SAP, COD_LINHA_DIGITAVEL, NUM_TITULO, IDE_SISTEMA, COD_USUARIO, COD_SITUACAODTH_PROCESSAMENTO
               FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
               
                END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
