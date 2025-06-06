using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 : QueryBasis<R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIOTOT,
            PRMVG,
            PRMAP,
            QTTITCAP,
            VLTITCAP,
            VLCUSTCAP,
            IMPSEGCDG,
            VLCUSTCDG,
            IMPSEGAUXF,
            VLCUSTAUXF,
            PRMDIT,
            QTDIT
            INTO :DCLPLANOS-VA-VGAP.IMPMORNATU,
            :DCLPLANOS-VA-VGAP.IMPMORACID,
            :DCLPLANOS-VA-VGAP.IMPINVPERM,
            :DCLPLANOS-VA-VGAP.IMPAMDS,
            :DCLPLANOS-VA-VGAP.IMPDH,
            :DCLPLANOS-VA-VGAP.IMPDIT,
            :DCLPLANOS-VA-VGAP.VLPREMIOTOT,
            :DCLPLANOS-VA-VGAP.PRMVG,
            :DCLPLANOS-VA-VGAP.PRMAP,
            :DCLPLANOS-VA-VGAP.QTTITCAP,
            :DCLPLANOS-VA-VGAP.VLTITCAP,
            :DCLPLANOS-VA-VGAP.VLCUSTCAP,
            :DCLPLANOS-VA-VGAP.IMPSEGCDG,
            :DCLPLANOS-VA-VGAP.VLCUSTCDG,
            :DCLPLANOS-VA-VGAP.IMPSEGAUXF,
            :DCLPLANOS-VA-VGAP.VLCUSTAUXF,
            :DCLPLANOS-VA-VGAP.PRMDIT,
            :DCLPLANOS-VA-VGAP.QTDIT
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE =
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE
            AND CODSUBES =
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO
            AND COD_PLANO =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO
            AND OPCAO_COBER =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER
            AND DTINIVIG <=
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND DTTERVIG >=
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND IDADE_INICIAL <= :WHOST-IDADE
            AND IDADE_FINAL >= :WHOST-IDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
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
											VLPREMIOTOT
							,
											PRMVG
							,
											PRMAP
							,
											QTTITCAP
							,
											VLTITCAP
							,
											VLCUSTCAP
							,
											IMPSEGCDG
							,
											VLCUSTCDG
							,
											IMPSEGAUXF
							,
											VLCUSTAUXF
							,
											PRMDIT
							,
											QTDIT
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE =
											'{this.PROPSSVD_NUM_APOLICE}'
											AND CODSUBES =
											'{this.PROPSSVD_COD_SUBGRUPO}'
											AND COD_PLANO =
											'{this.PROPOFID_COD_PLANO}'
											AND OPCAO_COBER =
											'{this.PROPOFID_OPCAO_COBER}'
											AND DTINIVIG <=
											'{this.PROPOFID_DTQITBCO}'
											AND DTTERVIG >=
											'{this.PROPOFID_DTQITBCO}'
											AND IDADE_INICIAL <= '{this.WHOST_IDADE}'
											AND IDADE_FINAL >= '{this.WHOST_IDADE}'";

            return query;
        }
        public string IMPMORNATU { get; set; }
        public string IMPMORACID { get; set; }
        public string IMPINVPERM { get; set; }
        public string IMPAMDS { get; set; }
        public string IMPDH { get; set; }
        public string IMPDIT { get; set; }
        public string VLPREMIOTOT { get; set; }
        public string PRMVG { get; set; }
        public string PRMAP { get; set; }
        public string QTTITCAP { get; set; }
        public string VLTITCAP { get; set; }
        public string VLCUSTCAP { get; set; }
        public string IMPSEGCDG { get; set; }
        public string VLCUSTCDG { get; set; }
        public string IMPSEGAUXF { get; set; }
        public string VLCUSTAUXF { get; set; }
        public string PRMDIT { get; set; }
        public string QTDIT { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WHOST_IDADE { get; set; }

        public static R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 Execute(R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1)
        {
            var ths = r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1();
            var i = 0;
            dta.IMPMORNATU = result[i++].Value?.ToString();
            dta.IMPMORACID = result[i++].Value?.ToString();
            dta.IMPINVPERM = result[i++].Value?.ToString();
            dta.IMPAMDS = result[i++].Value?.ToString();
            dta.IMPDH = result[i++].Value?.ToString();
            dta.IMPDIT = result[i++].Value?.ToString();
            dta.VLPREMIOTOT = result[i++].Value?.ToString();
            dta.PRMVG = result[i++].Value?.ToString();
            dta.PRMAP = result[i++].Value?.ToString();
            dta.QTTITCAP = result[i++].Value?.ToString();
            dta.VLTITCAP = result[i++].Value?.ToString();
            dta.VLCUSTCAP = result[i++].Value?.ToString();
            dta.IMPSEGCDG = result[i++].Value?.ToString();
            dta.VLCUSTCDG = result[i++].Value?.ToString();
            dta.IMPSEGAUXF = result[i++].Value?.ToString();
            dta.VLCUSTAUXF = result[i++].Value?.ToString();
            dta.PRMDIT = result[i++].Value?.ToString();
            dta.QTDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}