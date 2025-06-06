using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1 : QueryBasis<R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.COSSEGURO_HIST_PRE
            VALUES (:COSHISPR-COD-EMPRESA ,
            :COSHISPR-COD-CONGENERE ,
            :COSHISPR-NUM-APOLICE ,
            :COSHISPR-NUM-ENDOSSO ,
            :COSHISPR-NUM-PARCELA ,
            :COSHISPR-OCORR-HISTORICO ,
            :COSHISPR-COD-OPERACAO ,
            :COSHISPR-DATA-MOVIMENTO ,
            :COSHISPR-TIPO-SEGURO ,
            :COSHISPR-PRM-TARIFARIO ,
            :COSHISPR-VAL-DESCONTO ,
            :COSHISPR-PRM-LIQUIDO ,
            :COSHISPR-ADIC-FRACIONAMENTO,
            :COSHISPR-VAL-COMISSAO ,
            :COSHISPR-PRM-TOTAL ,
            CURRENT TIMESTAMP ,
            :COSHISPR-DATA-QUITACAO:VIND-DAT-QTBC,
            :COSHISPR-SIT-FINANCEIRA:VIND-SIT-FINC,
            :COSHISPR-SIT-LIBRECUP:VIND-SIT-LIBR,
            :COSHISPR-NUM-OCORRENCIA:VIND-NUM-OCOR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COSSEGURO_HIST_PRE VALUES ({FieldThreatment(this.COSHISPR_COD_EMPRESA)} , {FieldThreatment(this.COSHISPR_COD_CONGENERE)} , {FieldThreatment(this.COSHISPR_NUM_APOLICE)} , {FieldThreatment(this.COSHISPR_NUM_ENDOSSO)} , {FieldThreatment(this.COSHISPR_NUM_PARCELA)} , {FieldThreatment(this.COSHISPR_OCORR_HISTORICO)} , {FieldThreatment(this.COSHISPR_COD_OPERACAO)} , {FieldThreatment(this.COSHISPR_DATA_MOVIMENTO)} , {FieldThreatment(this.COSHISPR_TIPO_SEGURO)} , {FieldThreatment(this.COSHISPR_PRM_TARIFARIO)} , {FieldThreatment(this.COSHISPR_VAL_DESCONTO)} , {FieldThreatment(this.COSHISPR_PRM_LIQUIDO)} , {FieldThreatment(this.COSHISPR_ADIC_FRACIONAMENTO)}, {FieldThreatment(this.COSHISPR_VAL_COMISSAO)} , {FieldThreatment(this.COSHISPR_PRM_TOTAL)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DAT_QTBC?.ToInt() == -1 ? null : this.COSHISPR_DATA_QUITACAO))},  {FieldThreatment((this.VIND_SIT_FINC?.ToInt() == -1 ? null : this.COSHISPR_SIT_FINANCEIRA))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.COSHISPR_SIT_LIBRECUP))},  {FieldThreatment((this.VIND_NUM_OCOR?.ToInt() == -1 ? null : this.COSHISPR_NUM_OCORRENCIA))})";

            return query;
        }
        public string COSHISPR_COD_EMPRESA { get; set; }
        public string COSHISPR_COD_CONGENERE { get; set; }
        public string COSHISPR_NUM_APOLICE { get; set; }
        public string COSHISPR_NUM_ENDOSSO { get; set; }
        public string COSHISPR_NUM_PARCELA { get; set; }
        public string COSHISPR_OCORR_HISTORICO { get; set; }
        public string COSHISPR_COD_OPERACAO { get; set; }
        public string COSHISPR_DATA_MOVIMENTO { get; set; }
        public string COSHISPR_TIPO_SEGURO { get; set; }
        public string COSHISPR_PRM_TARIFARIO { get; set; }
        public string COSHISPR_VAL_DESCONTO { get; set; }
        public string COSHISPR_PRM_LIQUIDO { get; set; }
        public string COSHISPR_ADIC_FRACIONAMENTO { get; set; }
        public string COSHISPR_VAL_COMISSAO { get; set; }
        public string COSHISPR_PRM_TOTAL { get; set; }
        public string COSHISPR_DATA_QUITACAO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string COSHISPR_SIT_FINANCEIRA { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string COSHISPR_SIT_LIBRECUP { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string COSHISPR_NUM_OCORRENCIA { get; set; }
        public string VIND_NUM_OCOR { get; set; }

        public static void Execute(R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1 r2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1)
        {
            var ths = r2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}