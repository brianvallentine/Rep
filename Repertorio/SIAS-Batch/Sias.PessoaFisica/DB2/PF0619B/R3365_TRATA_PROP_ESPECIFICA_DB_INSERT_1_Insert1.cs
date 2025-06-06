using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 : QueryBasis<R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1>
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
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES ({FieldThreatment(this.PROPSSVD_NUM_IDENTIFICACAO)}, {FieldThreatment(this.PROPSSVD_DPS_TITULAR)}, {FieldThreatment(this.PROPSSVD_DPS_CONJUGE)}, {FieldThreatment(this.PROPSSVD_APOS_INVALIDEZ)}, {FieldThreatment(this.PROPSSVD_COD_USUARIO)}, {FieldThreatment(this.PROPSSVD_NUM_APOLICE)}, {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)}, CURRENT TIMESTAMP, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string PROPSSVD_NUM_IDENTIFICACAO { get; set; }
        public string PROPSSVD_DPS_TITULAR { get; set; }
        public string PROPSSVD_DPS_CONJUGE { get; set; }
        public string PROPSSVD_APOS_INVALIDEZ { get; set; }
        public string PROPSSVD_COD_USUARIO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }

        public static void Execute(R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1)
        {
            var ths = r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}