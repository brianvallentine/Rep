using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF,
            IDE_SEXO,
            DATA_NASCIMENTO
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-CGCCPF,
            :CLIENTES-IDE-SEXO:VIND-SEXO,
            :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
							,
											IDE_SEXO
							,
											DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string VIND_SEXO { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_IDE_SEXO = result[i++].Value?.ToString();
            dta.VIND_SEXO = string.IsNullOrWhiteSpace(dta.CLIENTES_IDE_SEXO) ? "-1" : "0";
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}