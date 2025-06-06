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
           77  sum(PRM-TARIFARIO)                 PIC X(254).
           77  sum(VAL-DESCONTO)                  PIC X(254).
           77  sum(VLPRMLIQ)                      PIC X(254).
           77  sum(VLADIFRA)                      PIC X(254).
           77  sum(VLCUSEMI)                      PIC X(254).
           77  sum(VLIOCC)                        PIC X(254).
           77  sum(VLPRMTOT)                      PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       NRPARCEL
sum(PRM-TARIFARIO)
sum(VAL-DESCONTO)
  sum(VLPRMLIQ)
  sum(VLADIFRA)
  sum(VLCUSEMI)
    sum(VLIOCC)
  sum(VLPRMTOT).

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT sum(PRM_TARIFARIO), sum(VAL_DESCONTO), sum(VLPRMLIQ), sum(VLADIFRA), sum(VLCUSEMI), sum(VLIOCC), sum(VLPRMTOT) FROM seguros.v1histoparc WHERE num_apolice = :NUM_APOLICE AND nrendos = :NRENDOS AND nrparcel = :NRPARCEL AND operacao IN (101, 801) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
