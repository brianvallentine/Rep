using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT D.DATA_INIVIGENCIA
            ,(D.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS)
            , E.DATA_INIVIGENCIA
            ,(E.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS)
            INTO :WHOST-DTINIVIG1
            ,:WHOST-DTTERVIG1
            ,:WHOST-DTINIVIG2
            ,:WHOST-DTTERVIG2
            FROM SEGUROS.HIST_CONT_PARCELVA A,
            SEGUROS.PARCELAS_VIDAZUL B,
            SEGUROS.OPCAO_PAG_VIDAZUL C,
            SEGUROS.HIS_COBER_PROPOST D,
            SEGUROS.ENDOSSOS E
            WHERE A.NUM_CERTIFICADO = :V0HCTB-NRCERTIF
            AND A.DTFATUR IS NULL
            AND A.SIT_REGISTRO IN ( '0' , '3' )
            AND A.DATA_MOVIMENTO <= :V1SIST-DTMOVABE
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO
            AND B.DATA_VENCIMENTO BETWEEN
            C.DATA_INIVIGENCIA AND C.DATA_TERVIGENCIA
            AND B.NUM_CERTIFICADO = D.NUM_CERTIFICADO
            AND B.DATA_VENCIMENTO BETWEEN
            D.DATA_INIVIGENCIA AND D.DATA_TERVIGENCIA
            AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO
            AND E.NUM_APOLICE = A.NUM_APOLICE
            AND E.NUM_ENDOSSO = 0
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT D.DATA_INIVIGENCIA
											,(D.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS)
											, E.DATA_INIVIGENCIA
											,(E.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS)
											FROM SEGUROS.HIST_CONT_PARCELVA A
							,
											SEGUROS.PARCELAS_VIDAZUL B
							,
											SEGUROS.OPCAO_PAG_VIDAZUL C
							,
											SEGUROS.HIS_COBER_PROPOST D
							,
											SEGUROS.ENDOSSOS E
											WHERE A.NUM_CERTIFICADO = '{this.V0HCTB_NRCERTIF}'
											AND A.DTFATUR IS NULL
											AND A.SIT_REGISTRO IN ( '0' 
							, '3' )
											AND A.DATA_MOVIMENTO <= '{this.V1SIST_DTMOVABE}'
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO
											AND B.DATA_VENCIMENTO BETWEEN
											C.DATA_INIVIGENCIA AND C.DATA_TERVIGENCIA
											AND B.NUM_CERTIFICADO = D.NUM_CERTIFICADO
											AND B.DATA_VENCIMENTO BETWEEN
											D.DATA_INIVIGENCIA AND D.DATA_TERVIGENCIA
											AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO
											AND E.NUM_APOLICE = A.NUM_APOLICE
											AND E.NUM_ENDOSSO = 0
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DTINIVIG1 { get; set; }
        public string WHOST_DTTERVIG1 { get; set; }
        public string WHOST_DTINIVIG2 { get; set; }
        public string WHOST_DTTERVIG2 { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 Execute(R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 r1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTINIVIG1 = result[i++].Value?.ToString();
            dta.WHOST_DTTERVIG1 = result[i++].Value?.ToString();
            dta.WHOST_DTINIVIG2 = result[i++].Value?.ToString();
            dta.WHOST_DTTERVIG2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}