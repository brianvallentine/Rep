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
           77  COD-EMPRESA                        PIC X(254).
           77  FONTE                              PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  CODPRODU                           PIC X(254).
           77  NUM-MATRICULA                      PIC X(254).
           77  TIPO-COBRANCA                      PIC X(254).
           77  AGECOBR                            PIC X(254).
           77  COD-AGENCIA                        PIC X(254).
           77  OPERACAO-CONTA                     PIC X(254).
           77  NUM-CONTA                          PIC X(254).
           77  DIG-CONTA                          PIC X(254).
           77  COD-AGENCIA-DEB                    PIC X(254).
           77  OPER-CONTA-DEB                     PIC X(254).
           77  NUM-CONTA-DEB                      PIC X(254).
           77  DIG-CONTA-DEB                      PIC X(254).
           77  NUM-CARTAO                         PIC X(254).
           77  DIA-DEBITO                         PIC X(254).
           77  NRCERTIF-AUTO                      PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    COD-EMPRESA
          FONTE
    NUM-APOLICE
        NRENDOS
       CODPRODU
  NUM-MATRICULA
  TIPO-COBRANCA
        AGECOBR
    COD-AGENCIA
 OPERACAO-CONTA
      NUM-CONTA
      DIG-CONTA
COD-AGENCIA-DEB
 OPER-CONTA-DEB
  NUM-CONTA-DEB
  DIG-CONTA-DEB
     NUM-CARTAO
     DIA-DEBITO
  NRCERTIF-AUTO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0apolcob (COD_EMPRESA, FONTE, NUM_APOLICE, NRENDOS, CODPRODU, NUM_MATRICULA, TIPO_COBRANCA, AGECOBR, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, NUM_CARTAO, DIA_DEBITO, NRCERTIF_AUTO, TIMESTAMP) VALUES (:COD_EMPRESA, :FONTE, :NUM_APOLICE, :NRENDOS, :CODPRODU, :NUM_MATRICULA, :TIPO_COBRANCA, :AGECOBR, :COD_AGENCIA, :OPERACAO_CONTA, :NUM_CONTA, :DIG_CONTA, :COD_AGENCIA_DEB, :OPER_CONTA_DEB, :NUM_CONTA_DEB, :DIG_CONTA_DEB, :NUM_CARTAO, :DIA_DEBITO, :NRCERTIF_AUTO, CURRENT TIMESTAMP) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
