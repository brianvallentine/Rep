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
           77  BCOCOBR                            PIC X(254).
           77  AGECOBR                            PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  t1.NUM-APOLICE                     PIC X(254).
           77  t1.NRENDOS                         PIC X(254).
           77  t1.NRPARCEL                        PIC X(254).
           77  T1.SITUACAO                        PIC X(254).
           77  t1.ocorhist                        PIC X(254).
           77  T2.BCOCOBR                         PIC X(254).
           77  T2.AGECOBR                         PIC X(254).
           77  T2.NRAVISO                         PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
        BCOCOBR
        AGECOBR
        NRAVISO
 t1.NUM-APOLICE
     t1.NRENDOS
    t1.NRPARCEL
    T1.SITUACAO
    t1.ocorhist
     T2.BCOCOBR
     T2.AGECOBR
     T2.NRAVISO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT t1.NUM_APOLICE, t1.NRENDOS, t1.NRPARCEL, T1.SITUACAO, t1.ocorhist, T2.BCOCOBR, T2.AGECOBR, T2.NRAVISO FROM seguros.v1parcela t1, seguros.v1parcela t2 WHERE t1.num_apolice = t2.num_apolice AND t1.nrendos = t2.nrendos AND t1.nrparcel = t2.nrparcel AND t1.ocorhist = t2.ocorhist AND t1.situacao = '1' AND t2.bcocobr = :BCOCOBR AND t2.agecobr = :AGECOBR AND t2.nraviso = :NRAVISO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
