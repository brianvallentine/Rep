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
    public class R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 : QueryBasis<R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES
            (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO,
            :DCLIDENTIFICA-RELAC.COD-PESSOA,
            :DCLIDENTIFICA-RELAC.COD-RELAC,
            :DCLIDENTIFICA-RELAC.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES ({FieldThreatment(this.NUM_IDENTIFICACAO)}, {FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.COD_RELAC)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string NUM_IDENTIFICACAO { get; set; }
        public string COD_PESSOA { get; set; }
        public string COD_RELAC { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1)
        {
            var ths = r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}