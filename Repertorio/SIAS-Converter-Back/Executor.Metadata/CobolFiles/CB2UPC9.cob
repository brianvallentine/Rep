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
           77  CODCLIEN                           PIC X(254).
           77  NUM-ITEM                           PIC X(254).
           77  CODSUBES                           PIC X(254).
           77  MODALIDA                           PIC X(254).
           77  ORGAO                              PIC X(254).
           77  RAMO                               PIC X(254).
           77  NUM-APOL-ANTERIOR                  PIC X(254).
           77  FONTE                              PIC X(254).
           77  NRPROPOS                           PIC X(254).
           77  DATPRO                             PIC X(254).
           77  DATA-LIBERACAO                     PIC X(254).
           77  DTEMIS                             PIC X(254).
           77  NUMBIL                             PIC X(254).
           77  TIPSEGU                            PIC X(254).
           77  TIPAPO                             PIC X(254).
           77  TIPCALC                            PIC X(254).
           77  PODPUBL                            PIC X(254).
           77  NUM-ATA                            PIC X(254).
           77  ANO-ATA                            PIC X(254).
           77  IDEMAN                             PIC X(254).
           77  NRRCAP                             PIC X(254).
           77  VLRCAP                             PIC X(254).
           77  BCORCAP                            PIC X(254).
           77  AGERCAP                            PIC X(254).
           77  DACRCAP                            PIC X(254).
           77  IDRCAP                             PIC X(254).
           77  BCOCOBR                            PIC X(254).
           77  AGECOBR                            PIC X(254).
           77  DACCOBR                            PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  CDFRACIO                           PIC X(254).
           77  PCENTRAD                           PIC X(254).
           77  PCADICIO                           PIC X(254).
           77  PCDESCON                           PIC X(254).
           77  PCIOCC                             PIC X(254).
           77  PRESTA1                            PIC X(254).
           77  QTPARCEL                           PIC X(254).
           77  QTPRESTA                           PIC X(254).
           77  QTITENS                            PIC X(254).
           77  CODTXT                             PIC X(254).
           77  CDACEITA                           PIC X(254).
           77  COD-MOEDA-IMP                      PIC X(254).
           77  COD-MOEDA-PRM                      PIC X(254).
           77  TIPO-ENDOSSO                       PIC X(254).
           77  TPCOSCED                           PIC X(254).
           77  QTCOSSEG                           PIC X(254).
           77  PCTCED                             PIC X(254).
           77  OCORR-ENDERECO                     PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  DATA-SORTEIO                       PIC X(254).
           77  DATARCAP                           PIC X(254).
           77  CORRECAO                           PIC X(254).
           77  COD-EMPRESA                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       CODCLIEN
       NUM-ITEM
       CODSUBES
       MODALIDA
          ORGAO
           RAMO
NUM-APOL-ANTERIOR
          FONTE
       NRPROPOS
         DATPRO
 DATA-LIBERACAO
         DTEMIS
         NUMBIL
        TIPSEGU
         TIPAPO
        TIPCALC
        PODPUBL
        NUM-ATA
        ANO-ATA
         IDEMAN
         NRRCAP
         VLRCAP
        BCORCAP
        AGERCAP
        DACRCAP
         IDRCAP
        BCOCOBR
        AGECOBR
        DACCOBR
       DTINIVIG
       DTTERVIG
       CDFRACIO
       PCENTRAD
       PCADICIO
       PCDESCON
         PCIOCC
        PRESTA1
       QTPARCEL
       QTPRESTA
        QTITENS
         CODTXT
       CDACEITA
  COD-MOEDA-IMP
  COD-MOEDA-PRM
   TIPO-ENDOSSO
       TPCOSCED
       QTCOSSEG
         PCTCED
 OCORR-ENDERECO
    COD-USUARIO
       SITUACAO
   DATA-SORTEIO
       DATARCAP
       CORRECAO
    COD-EMPRESA.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT CODCLIEN, NUM_APOLICE, NRENDOS, NUM_ITEM, CODSUBES, MODALIDA, ORGAO, RAMO, NUM_APOL_ANTERIOR, FONTE, NRPROPOS, DATPRO, DATA_LIBERACAO, DTEMIS, NUMBIL, TIPSEGU, TIPAPO, TIPCALC, PODPUBL, NUM_ATA, ANO_ATA, IDEMAN, NRRCAP, VLRCAP, BCORCAP, AGERCAP, DACRCAP, IDRCAP, BCOCOBR, AGECOBR, DACCOBR, DTINIVIG, DTTERVIG, CDFRACIO, PCENTRAD, PCADICIO, PCDESCON, PCIOCC, PRESTA1, QTPARCEL, QTPRESTA, QTITENS, CODTXT, CDACEITA, COD_MOEDA_IMP, COD_MOEDA_PRM, TIPO_ENDOSSO, TPCOSCED, QTCOSSEG, PCTCED, OCORR_ENDERECO, COD_USUARIO, SITUACAO, DATA_SORTEIO, DATARCAP, CORRECAO, COD_EMPRESA FROM seguros.v1endosso WHERE num_apolice = :NUM_APOLICE and nrendos = :NRENDOS END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
