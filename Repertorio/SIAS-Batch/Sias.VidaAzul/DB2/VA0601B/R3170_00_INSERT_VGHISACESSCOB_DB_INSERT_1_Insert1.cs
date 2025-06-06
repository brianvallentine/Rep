using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 : QueryBasis<R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_ACESS_COB
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            1,
            :VGPLAA-NUM-ACESSORIO,
            :VGPLAA-QTD-COBERTURA,
            :VGPLAA-IMPSEGURADA,
            :VGPLAA-CUSTO,
            :VGPLAA-PREMIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, 1, {FieldThreatment(this.VGPLAA_NUM_ACESSORIO)}, {FieldThreatment(this.VGPLAA_QTD_COBERTURA)}, {FieldThreatment(this.VGPLAA_IMPSEGURADA)}, {FieldThreatment(this.VGPLAA_CUSTO)}, {FieldThreatment(this.VGPLAA_PREMIO)})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGPLAA_NUM_ACESSORIO { get; set; }
        public string VGPLAA_QTD_COBERTURA { get; set; }
        public string VGPLAA_IMPSEGURADA { get; set; }
        public string VGPLAA_CUSTO { get; set; }
        public string VGPLAA_PREMIO { get; set; }

        public static void Execute(R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1)
        {
            var ths = r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}