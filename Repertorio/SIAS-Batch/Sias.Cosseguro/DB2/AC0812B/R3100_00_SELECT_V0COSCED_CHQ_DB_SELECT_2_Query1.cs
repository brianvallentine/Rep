using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1 : QueryBasis<R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO,
            VLRDESCON,
            VLRADIFRA,
            VLRCOMIS,
            VLRSINI,
            VLDESPESA,
            VLRHONOR,
            VLRSALVD,
            VLRESSARC,
            VALOR_EDI,
            VALOR_USS,
            VLEQPVNDA,
            VLDESPADM,
            OUTRDEBIT,
            OUTRCREDT,
            VLRSLDANT
            INTO :WHOST-VLRPREMIO,
            :WHOST-VLRDESCON,
            :WHOST-VLRADIFRA,
            :WHOST-VLR-COMIS,
            :WHOST-VLR-SINIS,
            :WHOST-VLDESPESA,
            :WHOST-VLR-HONOR,
            :WHOST-VLR-SALVD,
            :WHOST-VLRESSARC,
            :WHOST-VALOR-EDI,
            :WHOST-VALOR-USS,
            :WHOST-VLEQPVNDA,
            :WHOST-VLDESPADM,
            :WHOST-OUTRDEBIT,
            :WHOST-OUTRCREDT,
            :WHOST-VLRSLDANT
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V1RELA-COD-EMPR
            AND CONGENER = :V1RELA-CONGENER
            AND DTMOVTO_AC = :WHOST-DTMOVTO-AC
            AND SITUACAO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
							,
											VLRDESCON
							,
											VLRADIFRA
							,
											VLRCOMIS
							,
											VLRSINI
							,
											VLDESPESA
							,
											VLRHONOR
							,
											VLRSALVD
							,
											VLRESSARC
							,
											VALOR_EDI
							,
											VALOR_USS
							,
											VLEQPVNDA
							,
											VLDESPADM
							,
											OUTRDEBIT
							,
											OUTRCREDT
							,
											VLRSLDANT
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V1RELA_COD_EMPR}'
											AND CONGENER = '{this.V1RELA_CONGENER}'
											AND DTMOVTO_AC = '{this.WHOST_DTMOVTO_AC}'
											AND SITUACAO = '1'";

            return query;
        }
        public string WHOST_VLRPREMIO { get; set; }
        public string WHOST_VLRDESCON { get; set; }
        public string WHOST_VLRADIFRA { get; set; }
        public string WHOST_VLR_COMIS { get; set; }
        public string WHOST_VLR_SINIS { get; set; }
        public string WHOST_VLDESPESA { get; set; }
        public string WHOST_VLR_HONOR { get; set; }
        public string WHOST_VLR_SALVD { get; set; }
        public string WHOST_VLRESSARC { get; set; }
        public string WHOST_VALOR_EDI { get; set; }
        public string WHOST_VALOR_USS { get; set; }
        public string WHOST_VLEQPVNDA { get; set; }
        public string WHOST_VLDESPADM { get; set; }
        public string WHOST_OUTRDEBIT { get; set; }
        public string WHOST_OUTRCREDT { get; set; }
        public string WHOST_VLRSLDANT { get; set; }
        public string WHOST_DTMOVTO_AC { get; set; }
        public string V1RELA_COD_EMPR { get; set; }
        public string V1RELA_CONGENER { get; set; }

        public static R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1 Execute(R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1 r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1)
        {
            var ths = r3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_VLRPREMIO = result[i++].Value?.ToString();
            dta.WHOST_VLRDESCON = result[i++].Value?.ToString();
            dta.WHOST_VLRADIFRA = result[i++].Value?.ToString();
            dta.WHOST_VLR_COMIS = result[i++].Value?.ToString();
            dta.WHOST_VLR_SINIS = result[i++].Value?.ToString();
            dta.WHOST_VLDESPESA = result[i++].Value?.ToString();
            dta.WHOST_VLR_HONOR = result[i++].Value?.ToString();
            dta.WHOST_VLR_SALVD = result[i++].Value?.ToString();
            dta.WHOST_VLRESSARC = result[i++].Value?.ToString();
            dta.WHOST_VALOR_EDI = result[i++].Value?.ToString();
            dta.WHOST_VALOR_USS = result[i++].Value?.ToString();
            dta.WHOST_VLEQPVNDA = result[i++].Value?.ToString();
            dta.WHOST_VLDESPADM = result[i++].Value?.ToString();
            dta.WHOST_OUTRDEBIT = result[i++].Value?.ToString();
            dta.WHOST_OUTRCREDT = result[i++].Value?.ToString();
            dta.WHOST_VLRSLDANT = result[i++].Value?.ToString();
            return dta;
        }

    }
}