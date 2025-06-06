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
           77  CODSUBES                           PIC X(254).
           77  FONTE                              PIC X(254).
           77  RAMO                               PIC X(254).
           77  NRPROPOS                           PIC X(254).
           77  DATPRO                             PIC X(254).
           77  DATA-LIBERACAO                     PIC X(254).
           77  dtemis                             PIC X(254).
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
           77  PRESTA1                            PIC X(254).
           77  QTPARCEL                           PIC X(254).
           77  QTPRESTA                           PIC X(254).
           77  QTITENS                            PIC X(254).
           77  CODTXT                             PIC X(254).
           77  CDACEITA                           PIC X(254).
           77  COD-MOEDA-IMP                      PIC X(254).
           77  COD-MOEDA-PRM                      PIC X(254).
           77  TIPO-ENDOSSO                       PIC X(254).
           77  TIPSEGU                            PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  CORRECAO                           PIC X(254).
           77  OCORR-ENDERECO                     PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  DATARCAP                           PIC X(254).
           77  CODPRODU                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       CODSUBES
          FONTE
           RAMO
       NRPROPOS
         DATPRO
 DATA-LIBERACAO
         dtemis
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
        PRESTA1
       QTPARCEL
       QTPRESTA
        QTITENS
         CODTXT
       CDACEITA
  COD-MOEDA-IMP
  COD-MOEDA-PRM
   TIPO-ENDOSSO
        TIPSEGU
    COD-USUARIO
       CORRECAO
 OCORR-ENDERECO
       SITUACAO
       DATARCAP
       CODPRODU.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NRENDOS, CODSUBES, FONTE, RAMO, NRPROPOS, DATPRO, DATA_LIBERACAO, dtemis, NRRCAP, VLRCAP, BCORCAP, AGERCAP, DACRCAP, IDRCAP, BCOCOBR, AGECOBR, DACCOBR, DTINIVIG, DTTERVIG, CDFRACIO, PCENTRAD, PCADICIO, PRESTA1, QTPARCEL, QTPRESTA, QTITENS, CODTXT, CDACEITA, COD_MOEDA_IMP, COD_MOEDA_PRM, TIPO_ENDOSSO, TIPSEGU, COD_USUARIO, CORRECAO, OCORR_ENDERECO, SITUACAO, DATARCAP, CODPRODU FROM seguros.v1endosso WHERE num_apolice = :NUM_APOLICE AND nrendos = :NRENDOS END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
