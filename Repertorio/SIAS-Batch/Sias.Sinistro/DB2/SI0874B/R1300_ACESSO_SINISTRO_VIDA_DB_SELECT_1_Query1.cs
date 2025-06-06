using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1 : QueryBasis<R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SEGURVGA-COD-CLIENTE
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE
            AND COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO
            AND NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SINISMES_COD_SUBGRUPO}'
											AND NUM_CERTIFICADO = '{this.SINISMES_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1 Execute(R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1 r1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1)
        {
            var ths = r1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}