using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class M_2000_LOOP_TIME_DB_INSERT_1_Insert1 : QueryBasis<M_2000_LOOP_TIME_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.COMISSOES
            (NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            TIPO_SEGURADO ,
            NUM_PARCELA ,
            COD_OPERACAO ,
            COD_PRODUTOR ,
            RAMO_COBERTURA ,
            MODALI_COBERTURA ,
            OCORR_HISTORICO ,
            COD_FONTE ,
            COD_CLIENTE ,
            VAL_COMISSAO ,
            DATA_CALCULO ,
            NUM_RECIBO ,
            VAL_BASICO ,
            TIPO_COMISSAO ,
            QTD_PARCELAS ,
            PCT_COM_CORRETOR ,
            PCT_DESC_PREMIO ,
            COD_SUBGRUPO ,
            HORA_OPERACAO ,
            DATA_MOVIMENTO ,
            DATA_SELECAO ,
            COD_EMPRESA ,
            COD_PREPOSTO ,
            TIMESTAMP ,
            NUM_BILHETE ,
            VAL_VARMON ,
            DATA_QUITACAO)
            VALUES (:COMISSOE-NUM-APOLICE ,
            :COMISSOE-NUM-ENDOSSO ,
            :COMISSOE-NUM-CERTIFICADO ,
            :COMISSOE-DAC-CERTIFICADO ,
            :COMISSOE-TIPO-SEGURADO ,
            :COMISSOE-NUM-PARCELA ,
            :COMISSOE-COD-OPERACAO ,
            :COMISSOE-COD-PRODUTOR ,
            :COMISSOE-RAMO-COBERTURA ,
            :COMISSOE-MODALI-COBERTURA ,
            :COMISSOE-OCORR-HISTORICO ,
            :COMISSOE-COD-FONTE ,
            :COMISSOE-COD-CLIENTE ,
            :COMISSOE-VAL-COMISSAO ,
            :COMISSOE-DATA-CALCULO ,
            :COMISSOE-NUM-RECIBO ,
            :COMISSOE-VAL-BASICO ,
            :COMISSOE-TIPO-COMISSAO ,
            :COMISSOE-QTD-PARCELAS ,
            :COMISSOE-PCT-COM-CORRETOR ,
            :COMISSOE-PCT-DESC-PREMIO ,
            :COMISSOE-COD-SUBGRUPO ,
            :COMISSOE-HORA-OPERACAO ,
            NULL ,
            :COMISSOE-DATA-SELECAO ,
            NULL ,
            NULL ,
            CURRENT TIMESTAMP ,
            NULL ,
            NULL ,
            :COMISSOE-DATA-QUITACAO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMISSOES (NUM_APOLICE , NUM_ENDOSSO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_PARCELA , COD_OPERACAO , COD_PRODUTOR , RAMO_COBERTURA , MODALI_COBERTURA , OCORR_HISTORICO , COD_FONTE , COD_CLIENTE , VAL_COMISSAO , DATA_CALCULO , NUM_RECIBO , VAL_BASICO , TIPO_COMISSAO , QTD_PARCELAS , PCT_COM_CORRETOR , PCT_DESC_PREMIO , COD_SUBGRUPO , HORA_OPERACAO , DATA_MOVIMENTO , DATA_SELECAO , COD_EMPRESA , COD_PREPOSTO , TIMESTAMP , NUM_BILHETE , VAL_VARMON , DATA_QUITACAO) VALUES ({FieldThreatment(this.COMISSOE_NUM_APOLICE)} , {FieldThreatment(this.COMISSOE_NUM_ENDOSSO)} , {FieldThreatment(this.COMISSOE_NUM_CERTIFICADO)} , {FieldThreatment(this.COMISSOE_DAC_CERTIFICADO)} , {FieldThreatment(this.COMISSOE_TIPO_SEGURADO)} , {FieldThreatment(this.COMISSOE_NUM_PARCELA)} , {FieldThreatment(this.COMISSOE_COD_OPERACAO)} , {FieldThreatment(this.COMISSOE_COD_PRODUTOR)} , {FieldThreatment(this.COMISSOE_RAMO_COBERTURA)} , {FieldThreatment(this.COMISSOE_MODALI_COBERTURA)} , {FieldThreatment(this.COMISSOE_OCORR_HISTORICO)} , {FieldThreatment(this.COMISSOE_COD_FONTE)} , {FieldThreatment(this.COMISSOE_COD_CLIENTE)} , {FieldThreatment(this.COMISSOE_VAL_COMISSAO)} , {FieldThreatment(this.COMISSOE_DATA_CALCULO)} , {FieldThreatment(this.COMISSOE_NUM_RECIBO)} , {FieldThreatment(this.COMISSOE_VAL_BASICO)} , {FieldThreatment(this.COMISSOE_TIPO_COMISSAO)} , {FieldThreatment(this.COMISSOE_QTD_PARCELAS)} , {FieldThreatment(this.COMISSOE_PCT_COM_CORRETOR)} , {FieldThreatment(this.COMISSOE_PCT_DESC_PREMIO)} , {FieldThreatment(this.COMISSOE_COD_SUBGRUPO)} , {FieldThreatment(this.COMISSOE_HORA_OPERACAO)} , NULL , {FieldThreatment(this.COMISSOE_DATA_SELECAO)} , NULL , NULL , CURRENT TIMESTAMP , NULL , NULL , {FieldThreatment(this.COMISSOE_DATA_QUITACAO)})";

            return query;
        }
        public string COMISSOE_NUM_APOLICE { get; set; }
        public string COMISSOE_NUM_ENDOSSO { get; set; }
        public string COMISSOE_NUM_CERTIFICADO { get; set; }
        public string COMISSOE_DAC_CERTIFICADO { get; set; }
        public string COMISSOE_TIPO_SEGURADO { get; set; }
        public string COMISSOE_NUM_PARCELA { get; set; }
        public string COMISSOE_COD_OPERACAO { get; set; }
        public string COMISSOE_COD_PRODUTOR { get; set; }
        public string COMISSOE_RAMO_COBERTURA { get; set; }
        public string COMISSOE_MODALI_COBERTURA { get; set; }
        public string COMISSOE_OCORR_HISTORICO { get; set; }
        public string COMISSOE_COD_FONTE { get; set; }
        public string COMISSOE_COD_CLIENTE { get; set; }
        public string COMISSOE_VAL_COMISSAO { get; set; }
        public string COMISSOE_DATA_CALCULO { get; set; }
        public string COMISSOE_NUM_RECIBO { get; set; }
        public string COMISSOE_VAL_BASICO { get; set; }
        public string COMISSOE_TIPO_COMISSAO { get; set; }
        public string COMISSOE_QTD_PARCELAS { get; set; }
        public string COMISSOE_PCT_COM_CORRETOR { get; set; }
        public string COMISSOE_PCT_DESC_PREMIO { get; set; }
        public string COMISSOE_COD_SUBGRUPO { get; set; }
        public string COMISSOE_HORA_OPERACAO { get; set; }
        public string COMISSOE_DATA_SELECAO { get; set; }
        public string COMISSOE_DATA_QUITACAO { get; set; }

        public static void Execute(M_2000_LOOP_TIME_DB_INSERT_1_Insert1 m_2000_LOOP_TIME_DB_INSERT_1_Insert1)
        {
            var ths = m_2000_LOOP_TIME_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_LOOP_TIME_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}