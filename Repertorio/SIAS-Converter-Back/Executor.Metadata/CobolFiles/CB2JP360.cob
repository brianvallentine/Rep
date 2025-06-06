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
           77  DTMOVTO                            PIC X(254).
           77  COD-AGENCIA-DEB                    PIC X(254).
           77  OPER-CONTA-DEB                     PIC X(254).
           77  NUM-CONTA-DEB                      PIC X(254).
           77  DIG-CONTA-DEB                      PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  SIT-COBRANCA                       PIC X(254).
           77  DTENVIO                            PIC X(254).
           77  DTRETORNO                          PIC X(254).
           77  COD-RETORNO-CEF                    PIC X(254).
           77  NSAS                               PIC X(254).
           77  NUM-CARTAO                         PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NRPARCEL                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
        DTMOVTO
COD-AGENCIA-DEB
 OPER-CONTA-DEB
  NUM-CONTA-DEB
  DIG-CONTA-DEB
       DTVENCTO
   SIT-COBRANCA
        DTENVIO
      DTRETORNO
COD-RETORNO-CEF
           NSAS
     NUM-CARTAO
    COD-USUARIO
    NUM-APOLICE
        NRENDOS
       NRPARCEL.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR UPDATE seguros.v0movdebcc_cef SET DTMOVTO = :DTMOVTO, TIMESTAMP = CURRENT TIMESTAMP, COD_AGENCIA_DEB = :COD_AGENCIA_DEB, OPER_CONTA_DEB = :OPER_CONTA_DEB, NUM_CONTA_DEB = :NUM_CONTA_DEB, DIG_CONTA_DEB = :DIG_CONTA_DEB, DTVENCTO = :DTVENCTO, SIT_COBRANCA = :SIT_COBRANCA, DTENVIO = :DTENVIO, DTRETORNO = :DTRETORNO, COD_RETORNO_CEF = :COD_RETORNO_CEF, NSAS = :NSAS, NUM_CARTAO = :NUM_CARTAO, COD_USUARIO = :COD_USUARIO WHERE NUM_APOLICE = :NUM_APOLICE AND NRENDOS = :NRENDOS AND NRPARCEL = :NRPARCEL END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
