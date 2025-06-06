using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.SUBGRUPOS_VGAP A,
            SEGUROS.CLIENTES B
            WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND B.COD_CLIENTE = A.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NOME_RAZAO
											FROM SEGUROS.SUBGRUPOS_VGAP A
							,
											SEGUROS.CLIENTES B
											WHERE A.NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND B.COD_CLIENTE = A.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}