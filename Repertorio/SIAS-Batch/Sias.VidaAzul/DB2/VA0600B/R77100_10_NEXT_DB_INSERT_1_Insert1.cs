using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R77100_10_NEXT_DB_INSERT_1_Insert1 : QueryBasis<R77100_10_NEXT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES
            (:DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR,
            :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE,
            :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO,
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO,
            CURRENT TIMESTAMP,
            :PROPSSVD-NUM-CONTR-VINCULO:VIND-OPER-CREDITO,
            :PROPSSVD-COD-CORRESP-BANC :VIND-OPER-CREDITO,
            :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO ,
            :PROPSSVD-COD-OPER-CREDITO:VIND-OPER-CREDITO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES ({FieldThreatment(this.PROPSSVD_NUM_IDENTIFICACAO)}, {FieldThreatment(this.PROPSSVD_DPS_TITULAR)}, {FieldThreatment(this.PROPSSVD_DPS_CONJUGE)}, {FieldThreatment(this.PROPSSVD_APOS_INVALIDEZ)}, {FieldThreatment(this.PROPSSVD_COD_USUARIO)}, {FieldThreatment(this.PROPSSVD_NUM_APOLICE)}, {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_NUM_CONTR_VINCULO))},  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_COD_CORRESP_BANC))},  {FieldThreatment((this.VIND_NUM_PRAZO?.ToInt() == -1 ? null : this.PROPSSVD_NUM_PRAZO_FIN))} ,  {FieldThreatment((this.VIND_OPER_CREDITO?.ToInt() == -1 ? null : this.PROPSSVD_COD_OPER_CREDITO))})";

            return query;
        }
        public string PROPSSVD_NUM_IDENTIFICACAO { get; set; }
        public string PROPSSVD_DPS_TITULAR { get; set; }
        public string PROPSSVD_DPS_CONJUGE { get; set; }
        public string PROPSSVD_APOS_INVALIDEZ { get; set; }
        public string PROPSSVD_COD_USUARIO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPSSVD_NUM_CONTR_VINCULO { get; set; }
        public string VIND_OPER_CREDITO { get; set; }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string PROPSSVD_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO { get; set; }
        public string PROPSSVD_COD_OPER_CREDITO { get; set; }

        public static void Execute(R77100_10_NEXT_DB_INSERT_1_Insert1 r77100_10_NEXT_DB_INSERT_1_Insert1)
        {
            var ths = r77100_10_NEXT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R77100_10_NEXT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}