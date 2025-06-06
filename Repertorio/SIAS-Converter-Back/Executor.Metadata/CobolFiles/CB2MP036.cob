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
           77  NRPARCEL                           PIC X(254).
           77  DACPARC                            PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  HORAOPER                           PIC X(254).
           77  OCORHIST                           PIC X(254).
           77  PRM-TARIFARIO                      PIC X(254).
           77  VAL-DESCONTO                       PIC X(254).
           77  VLPRMLIQ                           PIC X(254).
           77  VLADIFRA                           PIC X(254).
           77  VLCUSEMI                           PIC X(254).
           77  VLIOCC                             PIC X(254).
           77  VLPRMTOT                           PIC X(254).
           77  VLPREMIO                           PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  BCOCOBR                            PIC X(254).
           77  AGECOBR                            PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  NRENDOCA                           PIC X(254).
           77  SITCONTB                           PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  RNUDOC                             PIC X(254).
           77  DTQITBCO                           PIC X(254).
           77  COD-EMPRESA                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       NRPARCEL
        DACPARC
        DTMOVTO
       OPERACAO
       HORAOPER
       OCORHIST
  PRM-TARIFARIO
   VAL-DESCONTO
       VLPRMLIQ
       VLADIFRA
       VLCUSEMI
         VLIOCC
       VLPRMTOT
       VLPREMIO
       DTVENCTO
        BCOCOBR
        AGECOBR
        NRAVISO
       NRENDOCA
       SITCONTB
    COD-USUARIO
         RNUDOC
       DTQITBCO
    COD-EMPRESA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0histoparc (NUM_APOLICE, NRENDOS, NRPARCEL, DACPARC, DTMOVTO, OPERACAO, HORAOPER, OCORHIST, PRM_TARIFARIO, VAL_DESCONTO, VLPRMLIQ, VLADIFRA, VLCUSEMI, VLIOCC, VLPRMTOT, VLPREMIO, DTVENCTO, BCOCOBR, AGECOBR, NRAVISO, NRENDOCA, SITCONTB, COD_USUARIO, RNUDOC, DTQITBCO, COD_EMPRESA, TIMESTAMP) VALUES (:NUM_APOLICE, :NRENDOS, :NRPARCEL, :DACPARC, :DTMOVTO, :OPERACAO, :HORAOPER, :OCORHIST, :PRM_TARIFARIO, :VAL_DESCONTO, :VLPRMLIQ, :VLADIFRA, :VLCUSEMI, :VLIOCC, :VLPRMTOT, :VLPREMIO, :DTVENCTO, :BCOCOBR, :AGECOBR, :NRAVISO, :NRENDOCA, :SITCONTB, :COD_USUARIO, :RNUDOC, :DTQITBCO, :COD_EMPRESA, CURRENT TIMESTAMP) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
