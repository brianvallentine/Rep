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
           77  NRENDOS                            PIC X(254).
           77  COD-CONVENIO                       PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  SIT-COBRANCA                       PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  VLR-DEBITO                         PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  DIA-DEBITO                         PIC X(254).
           77  COD-AGENCIA-DEB                    PIC X(254).
           77  OPER-CONTA-DEB                     PIC X(254).
           77  NUM-CONTA-DEB                      PIC X(254).
           77  DIG-CONTA-DEB                      PIC X(254).
           77  DTENVIO                            PIC X(254).
           77  DTRETORNO                          PIC X(254).
           77  COD-RETORNO-CEF                    PIC X(254).
           77  NSAS                               PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  NUM-CARTAO                         PIC X(254).
           77  SEQUENCIA                          PIC X(254).
           77  DTCREDITO                          PIC X(254).
           77  STATUS-CARTAO                      PIC X(254).
           77  VLR-CREDITO                        PIC X(254).
           77  NUM-REQUISICAO                     PIC X(254).
           77  DTVENCTO + 02 DAYS                 PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
   COD-CONVENIO
       NRPARCEL
   SIT-COBRANCA
       DTVENCTO
     VLR-DEBITO
        DTMOVTO
     DIA-DEBITO
COD-AGENCIA-DEB
 OPER-CONTA-DEB
  NUM-CONTA-DEB
  DIG-CONTA-DEB
        DTENVIO
      DTRETORNO
COD-RETORNO-CEF
           NSAS
    COD-USUARIO
     NUM-CARTAO
      SEQUENCIA
      DTCREDITO
  STATUS-CARTAO
    VLR-CREDITO
 NUM-REQUISICAO
DTVENCTO + 02 DAYS.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NRENDOS, NRPARCEL, SIT_COBRANCA, DTVENCTO, VLR_DEBITO, DTMOVTO, DIA_DEBITO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, COD_CONVENIO, DTENVIO, DTRETORNO, COD_RETORNO_CEF, NSAS, COD_USUARIO, NUM_CARTAO, SEQUENCIA, DTCREDITO, STATUS_CARTAO, VLR_CREDITO, NUM_REQUISICAO, DTVENCTO + 02 DAYS FROM seguros.v0movdebcc_cef WHERE NUM_APOLICE = :NUM_APOLICE AND NRENDOS = :NRENDOS AND COD_CONVENIO = :COD_CONVENIO ORDER BY NUM_APOLICE, NRENDOS, DTVENCTO DESC, NRPARCEL END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
