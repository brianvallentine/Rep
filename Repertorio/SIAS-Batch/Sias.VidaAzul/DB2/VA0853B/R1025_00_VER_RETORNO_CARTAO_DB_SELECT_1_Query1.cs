using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1 : QueryBasis<R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(T2.DTA_CREDITO, '0001-01-01' )
            INTO :GE408-DTA-CREDITO
            FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
            LEFT JOIN SEGUROS.GE_RETORNO_CA_CIELO T2
            ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
            AND T1.NUM_PARCELA = T2.NUM_PARCELA
            AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
            AND T2.COD_MOVIMENTO = '03'
            AND T2.COD_RETORNO = ' CC'
            WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND T1.NUM_PARCELA = :V0PROP-NRPARCEL
            AND T1.COD_IDLG = :WS-COD-IDLG
            AND T1.COD_TP_PAGAMENTO IN ( '01' , '02' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(T2.DTA_CREDITO
							, '0001-01-01' )
											FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
											LEFT
							JOIN SEGUROS.GE_RETORNO_CA_CIELO T2
											ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
											AND T1.NUM_PARCELA = T2.NUM_PARCELA
											AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
											AND T2.COD_MOVIMENTO = '03'
											AND T2.COD_RETORNO = ' CC'
											WHERE T1.NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND T1.NUM_PARCELA = '{this.V0PROP_NRPARCEL}'
											AND T1.COD_IDLG = '{this.WS_COD_IDLG}'
											AND T1.COD_TP_PAGAMENTO IN ( '01' 
							, '02' )
											WITH UR";

            return query;
        }
        public string GE408_DTA_CREDITO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string WS_COD_IDLG { get; set; }

        public static R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1 Execute(R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1 r1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1)
        {
            var ths = r1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE408_DTA_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}