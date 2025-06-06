using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 : QueryBasis<R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ENDOSSOS
            VALUES (:ENDOSSOS-NUM-APOLICE ,
            :ENDOSSOS-NUM-ENDOSSO ,
            :ENDOSSOS-RAMO-EMISSOR ,
            :ENDOSSOS-COD-PRODUTO ,
            :ENDOSSOS-COD-SUBGRUPO ,
            :ENDOSSOS-COD-FONTE ,
            :ENDOSSOS-NUM-PROPOSTA ,
            :ENDOSSOS-DATA-PROPOSTA ,
            :ENDOSSOS-DATA-LIBERACAO ,
            :ENDOSSOS-DATA-EMISSAO ,
            :ENDOSSOS-NUM-RCAP ,
            :ENDOSSOS-VAL-RCAP ,
            :ENDOSSOS-BCO-RCAP ,
            :ENDOSSOS-AGE-RCAP ,
            :ENDOSSOS-DAC-RCAP ,
            :ENDOSSOS-TIPO-RCAP ,
            :ENDOSSOS-BCO-COBRANCA ,
            :ENDOSSOS-AGE-COBRANCA ,
            :ENDOSSOS-DAC-COBRANCA ,
            :ENDOSSOS-DATA-INIVIGENCIA ,
            :ENDOSSOS-DATA-TERVIGENCIA ,
            :ENDOSSOS-PLANO-SEGURO ,
            :ENDOSSOS-PCT-ENTRADA ,
            :ENDOSSOS-PCT-ADIC-FRACIO ,
            :ENDOSSOS-QTD-DIAS-PRIMEIRA ,
            :ENDOSSOS-QTD-PARCELAS ,
            :ENDOSSOS-QTD-PRESTACOES ,
            :ENDOSSOS-QTD-ITENS ,
            :ENDOSSOS-COD-TEXTO-PADRAO ,
            :ENDOSSOS-COD-ACEITACAO ,
            :ENDOSSOS-COD-MOEDA-IMP ,
            :ENDOSSOS-COD-MOEDA-PRM ,
            :ENDOSSOS-TIPO-ENDOSSO ,
            :ENDOSSOS-COD-USUARIO ,
            :ENDOSSOS-OCORR-ENDERECO ,
            :ENDOSSOS-SIT-REGISTRO ,
            NULL ,
            NULL ,
            :ENDOSSOS-TIPO-CORRECAO ,
            :ENDOSSOS-ISENTA-CUSTO ,
            CURRENT_TIMESTAMP ,
            NULL ,
            NULL ,
            NULL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDOSSOS VALUES ({FieldThreatment(this.ENDOSSOS_NUM_APOLICE)} , {FieldThreatment(this.ENDOSSOS_NUM_ENDOSSO)} , {FieldThreatment(this.ENDOSSOS_RAMO_EMISSOR)} , {FieldThreatment(this.ENDOSSOS_COD_PRODUTO)} , {FieldThreatment(this.ENDOSSOS_COD_SUBGRUPO)} , {FieldThreatment(this.ENDOSSOS_COD_FONTE)} , {FieldThreatment(this.ENDOSSOS_NUM_PROPOSTA)} , {FieldThreatment(this.ENDOSSOS_DATA_PROPOSTA)} , {FieldThreatment(this.ENDOSSOS_DATA_LIBERACAO)} , {FieldThreatment(this.ENDOSSOS_DATA_EMISSAO)} , {FieldThreatment(this.ENDOSSOS_NUM_RCAP)} , {FieldThreatment(this.ENDOSSOS_VAL_RCAP)} , {FieldThreatment(this.ENDOSSOS_BCO_RCAP)} , {FieldThreatment(this.ENDOSSOS_AGE_RCAP)} , {FieldThreatment(this.ENDOSSOS_DAC_RCAP)} , {FieldThreatment(this.ENDOSSOS_TIPO_RCAP)} , {FieldThreatment(this.ENDOSSOS_BCO_COBRANCA)} , {FieldThreatment(this.ENDOSSOS_AGE_COBRANCA)} , {FieldThreatment(this.ENDOSSOS_DAC_COBRANCA)} , {FieldThreatment(this.ENDOSSOS_DATA_INIVIGENCIA)} , {FieldThreatment(this.ENDOSSOS_DATA_TERVIGENCIA)} , {FieldThreatment(this.ENDOSSOS_PLANO_SEGURO)} , {FieldThreatment(this.ENDOSSOS_PCT_ENTRADA)} , {FieldThreatment(this.ENDOSSOS_PCT_ADIC_FRACIO)} , {FieldThreatment(this.ENDOSSOS_QTD_DIAS_PRIMEIRA)} , {FieldThreatment(this.ENDOSSOS_QTD_PARCELAS)} , {FieldThreatment(this.ENDOSSOS_QTD_PRESTACOES)} , {FieldThreatment(this.ENDOSSOS_QTD_ITENS)} , {FieldThreatment(this.ENDOSSOS_COD_TEXTO_PADRAO)} , {FieldThreatment(this.ENDOSSOS_COD_ACEITACAO)} , {FieldThreatment(this.ENDOSSOS_COD_MOEDA_IMP)} , {FieldThreatment(this.ENDOSSOS_COD_MOEDA_PRM)} , {FieldThreatment(this.ENDOSSOS_TIPO_ENDOSSO)} , {FieldThreatment(this.ENDOSSOS_COD_USUARIO)} , {FieldThreatment(this.ENDOSSOS_OCORR_ENDERECO)} , {FieldThreatment(this.ENDOSSOS_SIT_REGISTRO)} , NULL , NULL , {FieldThreatment(this.ENDOSSOS_TIPO_CORRECAO)} , {FieldThreatment(this.ENDOSSOS_ISENTA_CUSTO)} , CURRENT_TIMESTAMP , NULL , NULL , NULL )";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_LIBERACAO { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDOSSOS_NUM_RCAP { get; set; }
        public string ENDOSSOS_VAL_RCAP { get; set; }
        public string ENDOSSOS_BCO_RCAP { get; set; }
        public string ENDOSSOS_AGE_RCAP { get; set; }
        public string ENDOSSOS_DAC_RCAP { get; set; }
        public string ENDOSSOS_TIPO_RCAP { get; set; }
        public string ENDOSSOS_BCO_COBRANCA { get; set; }
        public string ENDOSSOS_AGE_COBRANCA { get; set; }
        public string ENDOSSOS_DAC_COBRANCA { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_PLANO_SEGURO { get; set; }
        public string ENDOSSOS_PCT_ENTRADA { get; set; }
        public string ENDOSSOS_PCT_ADIC_FRACIO { get; set; }
        public string ENDOSSOS_QTD_DIAS_PRIMEIRA { get; set; }
        public string ENDOSSOS_QTD_PARCELAS { get; set; }
        public string ENDOSSOS_QTD_PRESTACOES { get; set; }
        public string ENDOSSOS_QTD_ITENS { get; set; }
        public string ENDOSSOS_COD_TEXTO_PADRAO { get; set; }
        public string ENDOSSOS_COD_ACEITACAO { get; set; }
        public string ENDOSSOS_COD_MOEDA_IMP { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }
        public string ENDOSSOS_COD_USUARIO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string ENDOSSOS_TIPO_CORRECAO { get; set; }
        public string ENDOSSOS_ISENTA_CUSTO { get; set; }

        public static void Execute(R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 r0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1)
        {
            var ths = r0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}