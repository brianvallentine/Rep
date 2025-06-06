using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1 : QueryBasis<R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.GE_CLIENTE_EMPRESA
            VALUES (
            :GE085-NUM-CERTIFICADO,
            :GE085-IND-TP-PROPOSTA,
            :GE085-COD-CLIENTE-PJ,
            :GE085-COD-ENDERECO-PJ,
            :GE085-COD-CLIENTE-PF,
            :GE085-COD-USUARIO,
            :GE085-NOM-PROGRAMA,
            CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CLIENTE_EMPRESA VALUES ( {FieldThreatment(this.GE085_NUM_CERTIFICADO)}, {FieldThreatment(this.GE085_IND_TP_PROPOSTA)}, {FieldThreatment(this.GE085_COD_CLIENTE_PJ)}, {FieldThreatment(this.GE085_COD_ENDERECO_PJ)}, {FieldThreatment(this.GE085_COD_CLIENTE_PF)}, {FieldThreatment(this.GE085_COD_USUARIO)}, {FieldThreatment(this.GE085_NOM_PROGRAMA)}, CURRENT TIMESTAMP )";

            return query;
        }
        public string GE085_NUM_CERTIFICADO { get; set; }
        public string GE085_IND_TP_PROPOSTA { get; set; }
        public string GE085_COD_CLIENTE_PJ { get; set; }
        public string GE085_COD_ENDERECO_PJ { get; set; }
        public string GE085_COD_CLIENTE_PF { get; set; }
        public string GE085_COD_USUARIO { get; set; }
        public string GE085_NOM_PROGRAMA { get; set; }

        public static void Execute(R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1 r4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1)
        {
            var ths = r4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}