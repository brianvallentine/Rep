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
           77  CODUSU                             PIC X(254).
           77  DATA-SOLICITACAO                   PIC X(254).
           77  IDSISTEM                           PIC X(254).
           77  CODRELAT                           PIC X(254).
           77  NRCOPIAS                           PIC X(254).
           77  QUANTIDADE                         PIC X(254).
           77  PERI-INICIAL                       PIC X(254).
           77  PERI-FINAL                         PIC X(254).
           77  DATA-REFERENCIA                    PIC X(254).
           77  MES-REFERENCIA                     PIC X(254).
           77  ANO-REFERENCIA                     PIC X(254).
           77  ORGAO                              PIC X(254).
           77  FONTE                              PIC X(254).
           77  CODPDT                             PIC X(254).
           77  RAMO                               PIC X(254).
           77  MODALIDA                           PIC X(254).
           77  CONGENER                           PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  NRCERTIF                           PIC X(254).
           77  NRTIT                              PIC X(254).
           77  CODSUBES                           PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  COD-PLANO                          PIC X(254).
           77  OCORHIST                           PIC X(254).
           77  APOLIDER                           PIC X(254).
           77  ENDOSLID                           PIC X(254).
           77  NUM-PARC-LIDER                     PIC X(254).
           77  NUM-SINISTRO                       PIC X(254).
           77  NUM-SINI-LIDER                     PIC X(254).
           77  NUM-ORDEM                          PIC X(254).
           77  CODUNIMO                           PIC X(254).
           77  CORRECAO                           PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  COD-EMPRESA                        PIC X(254).
           77  PREVIA-DEFINITIVA                  PIC X(254).
           77  ANAL-RESUMO                        PIC X(254).
           77  PERI-RENOVACAO                     PIC X(254).
           77  PCT-AUMENTO                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
         CODUSU
DATA-SOLICITACAO
       IDSISTEM
       CODRELAT
       NRCOPIAS
     QUANTIDADE
   PERI-INICIAL
     PERI-FINAL
DATA-REFERENCIA
 MES-REFERENCIA
 ANO-REFERENCIA
          ORGAO
          FONTE
         CODPDT
           RAMO
       MODALIDA
       CONGENER
    NUM-APOLICE
        NRENDOS
       NRPARCEL
       NRCERTIF
          NRTIT
       CODSUBES
       OPERACAO
      COD-PLANO
       OCORHIST
       APOLIDER
       ENDOSLID
 NUM-PARC-LIDER
   NUM-SINISTRO
 NUM-SINI-LIDER
      NUM-ORDEM
       CODUNIMO
       CORRECAO
       SITUACAO
    COD-EMPRESA
PREVIA-DEFINITIVA
    ANAL-RESUMO
 PERI-RENOVACAO
    PCT-AUMENTO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0relatorios (CODUSU, DATA_SOLICITACAO, IDSISTEM, CODRELAT, NRCOPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO, FONTE, CODPDT, RAMO, MODALIDA, CONGENER, NUM_APOLICE, NRENDOS, NRPARCEL, NRCERTIF, NRTIT, CODSUBES, OPERACAO, COD_PLANO, OCORHIST, APOLIDER, ENDOSLID, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, CODUNIMO, CORRECAO, SITUACAO, COD_EMPRESA, PREVIA_DEFINITIVA, ANAL_RESUMO, PERI_RENOVACAO, PCT_AUMENTO) VALUES (:CODUSU, :DATA_SOLICITACAO, :IDSISTEM, :CODRELAT, :NRCOPIAS, :QUANTIDADE, :PERI_INICIAL, :PERI_FINAL, :DATA_REFERENCIA, :MES_REFERENCIA, :ANO_REFERENCIA, :ORGAO, :FONTE, :CODPDT, :RAMO, :MODALIDA, :CONGENER, :NUM_APOLICE, :NRENDOS, :NRPARCEL, :NRCERTIF, :NRTIT, :CODSUBES, :OPERACAO, :COD_PLANO, :OCORHIST, :APOLIDER, :ENDOSLID, :NUM_PARC_LIDER, :NUM_SINISTRO, :NUM_SINI_LIDER, :NUM_ORDEM, :CODUNIMO, :CORRECAO, :SITUACAO, :COD_EMPRESA, :PREVIA_DEFINITIVA, :ANAL_RESUMO, :PERI_RENOVACAO, :PCT_AUMENTO) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
