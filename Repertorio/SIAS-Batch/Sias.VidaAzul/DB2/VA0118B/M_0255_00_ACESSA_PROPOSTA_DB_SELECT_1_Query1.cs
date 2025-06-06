using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO_SIVPF
            , AGECTADEB
            , OPRCTADEB
            , NUMCTADEB
            , DIGCTADEB
            , VAL_PAGO
            INTO :PROPOFID-COD-PRODUTO-SIVPF
            , :PROPOFID-AGECTADEB
            , :PROPOFID-OPRCTADEB
            , :PROPOFID-NUMCTADEB
            , :PROPOFID-DIGCTADEB
            , :PROPOFID-VAL-PAGO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPVA-NRCERTIF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO_SIVPF
											, AGECTADEB
											, OPRCTADEB
											, NUMCTADEB
											, DIGCTADEB
											, VAL_PAGO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPVA_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1 Execute(M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1 m_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = m_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            return dta;
        }

    }
}