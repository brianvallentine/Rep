using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 : QueryBasis<R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.ERROS_PROP_VIDAZUL
            VALUES
            (
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLERROS-PROP-VIDAZUL.COD-ERRO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ( {FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.COD_ERRO)} )";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string COD_ERRO { get; set; }

        public static void Execute(R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}