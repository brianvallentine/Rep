using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 : QueryBasis<R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1>
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

        public static void Execute(R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1)
        {
            var ths = r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}