using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE,
            A.COD_SUBGRUPO,
            A.NUM_ITEM,
            A.OCORR_HISTORICO,
            B.COD_PRODUTO,
            D.COD_PRODUTO,
            VALUE(C.IND_IOF, 'S' ),
            B.NUM_CERTIFICADO,
            C.PERI_FATURAMENTO,
            D.ORIG_PRODU
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO,
            :PROPOVA-COD-PRODUTO,
            :PRODUVG-COD-PRODUTO,
            :V0SUBG-IND-IOF,
            :PROPOVA-NUM-CERTIFICADO,
            :SEGVGAP-PERI-PAGAMENTO,
            :PRODUVG-ORIG-PRODU
            FROM SEGUROS.SEGURADOS_VGAP A,
            SEGUROS.PROPOSTAS_VA B,
            SEGUROS.SUBGRUPOS_VGAP C,
            SEGUROS.PRODUTOS_VG D
            WHERE A.NUM_CERTIFICADO = :WS-NUM-CERTIFICADO
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.TIPO_SEGURADO = '1'
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.NUM_APOLICE = C.NUM_APOLICE
            AND A.COD_SUBGRUPO = C.COD_SUBGRUPO
            AND A.NUM_APOLICE = D.NUM_APOLICE
            AND A.COD_SUBGRUPO = D.COD_SUBGRUPO
            ORDER BY A.COD_SUBGRUPO DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
							,
											A.COD_SUBGRUPO
							,
											A.NUM_ITEM
							,
											A.OCORR_HISTORICO
							,
											B.COD_PRODUTO
							,
											D.COD_PRODUTO
							,
											VALUE(C.IND_IOF
							, 'S' )
							,
											B.NUM_CERTIFICADO
							,
											C.PERI_FATURAMENTO
							,
											D.ORIG_PRODU
											FROM SEGUROS.SEGURADOS_VGAP A
							,
											SEGUROS.PROPOSTAS_VA B
							,
											SEGUROS.SUBGRUPOS_VGAP C
							,
											SEGUROS.PRODUTOS_VG D
											WHERE A.NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO}'
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.TIPO_SEGURADO = '1'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.NUM_APOLICE = C.NUM_APOLICE
											AND A.COD_SUBGRUPO = C.COD_SUBGRUPO
											AND A.NUM_APOLICE = D.NUM_APOLICE
											AND A.COD_SUBGRUPO = D.COD_SUBGRUPO
											ORDER BY A.COD_SUBGRUPO DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string V0SUBG_IND_IOF { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string SEGVGAP_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1 m_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = m_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.V0SUBG_IND_IOF = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGVGAP_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}