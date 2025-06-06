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
           77  CODPDT                             PIC X(254).
           77  FONTE                              PIC X(254).
           77  TIPO-PRODUTOR                      PIC X(254).
           77  NOMPDT                             PIC X(254).
           77  CHPFUN                             PIC X(254).
           77  CODHIE                             PIC X(254).
           77  NOMCTT                             PIC X(254).
           77  ENDERECO                           PIC X(254).
           77  BAIRRO                             PIC X(254).
           77  CIDADE                             PIC X(254).
           77  ESTADO                             PIC X(254).
           77  CEP                                PIC X(254).
           77  DDD                                PIC X(254).
           77  TELEFONE                           PIC X(254).
           77  TELEX                              PIC X(254).
           77  RGSUSEP                            PIC X(254).
           77  NRTITHAB                           PIC X(254).
           77  RGVIDA                             PIC X(254).
           77  CGCCPF                             PIC X(254).
           77  INSPREFE                           PIC X(254).
           77  INSINPS                            PIC X(254).
           77  TPPESSOA                           PIC X(254).
           77  DCOIRF                             PIC X(254).
           77  PCDESISS                           PIC X(254).
           77  NOMEPROC                           PIC X(254).
           77  PRAPAG                             PIC X(254).
           77  BANCO                              PIC X(254).
           77  AGENCIA                            PIC X(254).
           77  NRCONTAC                           PIC X(254).
           77  DAC-CTA-CORRENTE                   PIC X(254).
           77  TABCOM                             PIC X(254).
           77  BASPAG                             PIC X(254).
           77  APVALD                             PIC X(254).
           77  CHPATZ                             PIC X(254).
           77  DATVIG                             PIC X(254).
           77  DTCADAST                           PIC X(254).
           77  DTULTMOV                           PIC X(254).
           77  NUMREC                             PIC X(254).
           77  CODCORR                            PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  COD-EMPRESA                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
         CODPDT
          FONTE
  TIPO-PRODUTOR
         NOMPDT
         CHPFUN
         CODHIE
         NOMCTT
       ENDERECO
         BAIRRO
         CIDADE
         ESTADO
            CEP
            DDD
       TELEFONE
          TELEX
        RGSUSEP
       NRTITHAB
         RGVIDA
         CGCCPF
       INSPREFE
        INSINPS
       TPPESSOA
         DCOIRF
       PCDESISS
       NOMEPROC
         PRAPAG
          BANCO
        AGENCIA
       NRCONTAC
DAC-CTA-CORRENTE
         TABCOM
         BASPAG
         APVALD
         CHPATZ
         DATVIG
       DTCADAST
       DTULTMOV
         NUMREC
        CODCORR
       SITUACAO
    COD-EMPRESA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT FONTE, CODPDT, TIPO_PRODUTOR, NOMPDT, CHPFUN, CODHIE, NOMCTT, ENDERECO, BAIRRO, CIDADE, ESTADO, CEP, DDD, TELEFONE, TELEX, RGSUSEP, NRTITHAB, RGVIDA, CGCCPF, INSPREFE, INSINPS, TPPESSOA, DCOIRF, PCDESISS, NOMEPROC, PRAPAG, BANCO, AGENCIA, NRCONTAC, DAC_CTA_CORRENTE, TABCOM, BASPAG, APVALD, CHPATZ, DATVIG, DTCADAST, DTULTMOV, NUMREC, CODCORR, SITUACAO, COD_EMPRESA FROM seguros.v1produtor WHERE codpdt = :CODPDT END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
