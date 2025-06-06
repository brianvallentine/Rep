using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0004S
{
    public class M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1 : QueryBasis<M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT COD_PRODUTO_SIVPF ,
            COD_RELAC ,
            COD_EMPRESA_SIVPF
            INTO :PRDSIVPF-COD-PRODUTO-SIVPF ,
            :PRDSIVPF-COD-RELAC ,
            :PRDSIVPF-COD-EMPRESA-SIVPF
            FROM SEGUROS.PRODUTOS_SIVPF
            WHERE COD_PRODUTO_SIVPF = :BI0004L-E-COD-PRD-SIG
            AND DTH_INI_VIGENCIA < :BI0004L-E-DAT-SIS
            AND DTH_FIM_VIGENCIA > :BI0004L-E-DAT-SIS
            ORDER BY COD_PRODUTO_SIVPF, COD_RELAC, COD_EMPRESA_SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT COD_PRODUTO_SIVPF 
							,
											COD_RELAC 
							,
											COD_EMPRESA_SIVPF
											FROM SEGUROS.PRODUTOS_SIVPF
											WHERE COD_PRODUTO_SIVPF = '{this.BI0004L_E_COD_PRD_SIG}'
											AND DTH_INI_VIGENCIA < '{this.BI0004L_E_DAT_SIS}'
											AND DTH_FIM_VIGENCIA > '{this.BI0004L_E_DAT_SIS}'
											ORDER BY COD_PRODUTO_SIVPF
							, COD_RELAC
							, COD_EMPRESA_SIVPF
											WITH UR";

            return query;
        }
        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }
        public string PRDSIVPF_COD_RELAC { get; set; }
        public string PRDSIVPF_COD_EMPRESA_SIVPF { get; set; }
        public string BI0004L_E_COD_PRD_SIG { get; set; }
        public string BI0004L_E_DAT_SIS { get; set; }

        public static M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1 Execute(M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1 m_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1)
        {
            var ths = m_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRDSIVPF_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_RELAC = result[i++].Value?.ToString();
            dta.PRDSIVPF_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}