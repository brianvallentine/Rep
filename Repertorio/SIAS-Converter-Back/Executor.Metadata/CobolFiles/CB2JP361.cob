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
           77  COD-LOT-FENAL                      PIC X(254).
           77  COD-LOT-CEF                        PIC X(254).
           77  COD-CLIENTE                        PIC X(254).
           77  OCORR-ENDERECO                     PIC X(254).
           77  OPCAO-DEP                          PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  FORMA-PAGTO                        PIC X(254).
           77  NUM-CONTROLE-FENAL                 PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  BANCO                              PIC X(254).
           77  AGENCIA                            PIC X(254).
           77  OPERACAO-CONTA                     PIC X(254).
           77  NUMERO-CONTA                       PIC X(254).
           77  DV-CONTA                           PIC X(254).
           77  DATA-GERA-MOV                      PIC X(254).
           77  COD-EMPRESA                        PIC X(254).
           77  SINDICATO                          PIC X(254).
           77  TIMESTAMP                          PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  DES-EMAIL                          PIC X(254).
           77  NUM-TITULO                         PIC X(254).
           77  DATA-QUITACAO                      PIC X(254).
           77  TAXA-VLR-INICIAL                   PIC X(254).
           77  TAXA-VLR-ATUAL                     PIC X(254).
           77  DESC-SIN-ACUM                      PIC X(254).
           77  NOME-FANTASIA                      PIC X(254).
           77  NUM-PVCEF                          PIC X(254).
           77  NUM-ENCEF                          PIC X(254).
           77  ENDERECO                           PIC X(254).
           77  COMPL-ENDERECO                     PIC X(254).
           77  BAIRRO                             PIC X(254).
           77  CEP                                PIC X(254).
           77  CIDADE                             PIC X(254).
           77  SIGLA-UF                           PIC X(254).
           77  DDD                                PIC X(254).
           77  NUM-FONE                           PIC X(254).
           77  NUM-FAX                            PIC X(254).
           77  COD-CANCELAMENTO                   PIC X(254).
           77  DATA-CANCELAMENTO                  PIC X(254).
           77  COD-FONTE                          PIC X(254).
           77  NUM-PROPOSTA                       PIC X(254).
           77  COD-CLASSE-ADESAO                  PIC X(254).
           77  COD-MUNICIPIO                      PIC X(254).
           77  QTD-PARCELAS                       PIC X(254).
           77  PCT-JUROS                          PIC X(254).
           77  IND-RENOVACAO                      PIC X(254).
           77  NUM-CLASSE                         PIC X(254).
           77  DTH-INIVIG-CLASSE                  PIC X(254).
           77  DTH-TERVIG-CLASSE                  PIC X(254).
           77  IND-REGIAO                         PIC X(254).
           77  STA-SEGURADO                       PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
  COD-LOT-FENAL
    COD-LOT-CEF
    COD-CLIENTE
 OCORR-ENDERECO
      OPCAO-DEP
       DTINIVIG
       DTTERVIG
    FORMA-PAGTO
NUM-CONTROLE-FENAL
       SITUACAO
          BANCO
        AGENCIA
 OPERACAO-CONTA
   NUMERO-CONTA
       DV-CONTA
  DATA-GERA-MOV
    COD-EMPRESA
      SINDICATO
      TIMESTAMP
    NUM-APOLICE
      DES-EMAIL
     NUM-TITULO
  DATA-QUITACAO
TAXA-VLR-INICIAL
 TAXA-VLR-ATUAL
  DESC-SIN-ACUM
  NOME-FANTASIA
      NUM-PVCEF
      NUM-ENCEF
       ENDERECO
 COMPL-ENDERECO
         BAIRRO
            CEP
         CIDADE
       SIGLA-UF
            DDD
       NUM-FONE
        NUM-FAX
COD-CANCELAMENTO
DATA-CANCELAMENTO
      COD-FONTE
   NUM-PROPOSTA
COD-CLASSE-ADESAO
  COD-MUNICIPIO
   QTD-PARCELAS
      PCT-JUROS
  IND-RENOVACAO
     NUM-CLASSE
DTH-INIVIG-CLASSE
DTH-TERVIG-CLASSE
     IND-REGIAO
   STA-SEGURADO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT COD_LOT_FENAL, COD_LOT_CEF, COD_CLIENTE, OCORR_ENDERECO, OPCAO_DEP, DTINIVIG, DTTERVIG, FORMA_PAGTO, NUM_CONTROLE_FENAL, SITUACAO, BANCO, AGENCIA, OPERACAO_CONTA, NUMERO_CONTA, DV_CONTA, DATA_GERA_MOV, COD_EMPRESA, SINDICATO, TIMESTAMP, NUM_APOLICE, DES_EMAIL, NUM_TITULO, DATA_QUITACAO, TAXA_VLR_INICIAL, TAXA_VLR_ATUAL, DESC_SIN_ACUM, NOME_FANTASIA, NUM_PVCEF, NUM_ENCEF, ENDERECO, COMPL_ENDERECO, BAIRRO, CEP, CIDADE, SIGLA_UF, DDD, NUM_FONE, NUM_FAX, COD_CANCELAMENTO, DATA_CANCELAMENTO, COD_FONTE, NUM_PROPOSTA, COD_CLASSE_ADESAO, COD_MUNICIPIO, QTD_PARCELAS, PCT_JUROS, IND_RENOVACAO, NUM_CLASSE, DTH_INIVIG_CLASSE, DTH_TERVIG_CLASSE, IND_REGIAOSTA_SEGURADO
               FROM SEGUROS.LOTERICO01
               
                END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
