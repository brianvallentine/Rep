using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.AGECOBR,
            A.DATA_PROPOSTA,
            C.COD_FONTE
            INTO :PROPOFID-AGECOBR ,
            :PROPOFID-DATA-PROPOSTA,
            :MALHACEF-COD-FONTE
            FROM SEGUROS.PROPOSTA_FIDELIZ A,
            SEGUROS.AGENCIAS_CEF B,
            SEGUROS.MALHA_CEF C
            WHERE A.NUM_PROPOSTA_SIVPF =
            :MOVIMCOB-NUM-NOSSO-TITULO
            AND B.COD_AGENCIA =
            A.AGECOBR
            AND C.COD_SUREG =
            B.COD_SUREG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.AGECOBR
							,
											A.DATA_PROPOSTA
							,
											C.COD_FONTE
											FROM SEGUROS.PROPOSTA_FIDELIZ A
							,
											SEGUROS.AGENCIAS_CEF B
							,
											SEGUROS.MALHA_CEF C
											WHERE A.NUM_PROPOSTA_SIVPF =
											'{this.MOVIMCOB_NUM_NOSSO_TITULO}'
											AND B.COD_AGENCIA =
											A.AGECOBR
											AND C.COD_SUREG =
											B.COD_SUREG
											WITH UR";

            return query;
        }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string MALHACEF_COD_FONTE { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }

        public static R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_AGECOBR = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}