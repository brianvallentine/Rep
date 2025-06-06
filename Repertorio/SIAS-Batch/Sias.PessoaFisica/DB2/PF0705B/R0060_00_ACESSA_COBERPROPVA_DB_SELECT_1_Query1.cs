using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            IMPSEGUR,
            IMP_MORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP
            INTO :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO,
            :DCLHIS-COBER-PROPOST.DATA-INIVIGENCIA,
            :DCLHIS-COBER-PROPOST.DATA-TERVIGENCIA,
            :DCLHIS-COBER-PROPOST.IMPSEGUR,
            :DCLHIS-COBER-PROPOST.IMP-MORNATU,
            :DCLHIS-COBER-PROPOST.IMPMORACID,
            :DCLHIS-COBER-PROPOST.IMPINVPERM,
            :DCLHIS-COBER-PROPOST.IMPAMDS,
            :DCLHIS-COBER-PROPOST.IMPDH,
            :DCLHIS-COBER-PROPOST.IMPDIT,
            :DCLHIS-COBER-PROPOST.VLPREMIO,
            :DCLHIS-COBER-PROPOST.PRMVG,
            :DCLHIS-COBER-PROPOST.PRMAP
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO =
            :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO
            AND COD_OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
							,
											IMPSEGUR
							,
											IMP_MORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
							,
											VLPREMIO
							,
											PRMVG
							,
											PRMAP
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											AND COD_OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string NUM_CERTIFICADO { get; set; }
        public string DATA_INIVIGENCIA { get; set; }
        public string DATA_TERVIGENCIA { get; set; }
        public string IMPSEGUR { get; set; }
        public string IMP_MORNATU { get; set; }
        public string IMPMORACID { get; set; }
        public string IMPINVPERM { get; set; }
        public string IMPAMDS { get; set; }
        public string IMPDH { get; set; }
        public string IMPDIT { get; set; }
        public string VLPREMIO { get; set; }
        public string PRMVG { get; set; }
        public string PRMAP { get; set; }

        public static R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 Execute(R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 r0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.IMPSEGUR = result[i++].Value?.ToString();
            dta.IMP_MORNATU = result[i++].Value?.ToString();
            dta.IMPMORACID = result[i++].Value?.ToString();
            dta.IMPINVPERM = result[i++].Value?.ToString();
            dta.IMPAMDS = result[i++].Value?.ToString();
            dta.IMPDH = result[i++].Value?.ToString();
            dta.IMPDIT = result[i++].Value?.ToString();
            dta.VLPREMIO = result[i++].Value?.ToString();
            dta.PRMVG = result[i++].Value?.ToString();
            dta.PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}