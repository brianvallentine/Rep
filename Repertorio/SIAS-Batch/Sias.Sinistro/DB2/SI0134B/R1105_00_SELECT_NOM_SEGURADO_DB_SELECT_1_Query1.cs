using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TT1.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES TT1,
            SEGUROS.SEGURADOS_VGAP TT2
            WHERE
            TT2.NUM_APOLICE = :SINISMES-NUM-APOLICE
            AND TT2.COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO
            AND TT2.NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO
            AND TT2.TIPO_SEGURADO = '1'
            AND TT2.COD_CLIENTE = TT1.COD_CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TT1.NOME_RAZAO
											FROM SEGUROS.CLIENTES TT1
							,
											SEGUROS.SEGURADOS_VGAP TT2
											WHERE
											TT2.NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											AND TT2.COD_SUBGRUPO = '{this.SINISMES_COD_SUBGRUPO}'
											AND TT2.NUM_CERTIFICADO = '{this.SINISMES_NUM_CERTIFICADO}'
											AND TT2.TIPO_SEGURADO = '1'
											AND TT2.COD_CLIENTE = TT1.COD_CLIENTE
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 Execute(R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 r1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}