using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class R1100_SELECT_VEICULO_DB_SELECT_1_Query1 : QueryBasis<R1100_SELECT_VEICULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_VEICULO
            INTO :VEICUDES-DESCR-VEICULO
            FROM SEGUROS.VEICULOS_DESCRICAO
            WHERE VERSAO = :VEICUDES-VERSAO
            AND COD_FABRICANTE = :APOLIAUT-COD-FABRICANTE
            AND COD_VEICULO = :APOLIAUT-COD-VEICULO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DESCR_VEICULO
											FROM SEGUROS.VEICULOS_DESCRICAO
											WHERE VERSAO = '{this.VEICUDES_VERSAO}'
											AND COD_FABRICANTE = '{this.APOLIAUT_COD_FABRICANTE}'
											AND COD_VEICULO = '{this.APOLIAUT_COD_VEICULO}'";

            return query;
        }
        public string VEICUDES_DESCR_VEICULO { get; set; }
        public string APOLIAUT_COD_FABRICANTE { get; set; }
        public string APOLIAUT_COD_VEICULO { get; set; }
        public string VEICUDES_VERSAO { get; set; }

        public static R1100_SELECT_VEICULO_DB_SELECT_1_Query1 Execute(R1100_SELECT_VEICULO_DB_SELECT_1_Query1 r1100_SELECT_VEICULO_DB_SELECT_1_Query1)
        {
            var ths = r1100_SELECT_VEICULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_SELECT_VEICULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_SELECT_VEICULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VEICUDES_DESCR_VEICULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}