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
    public class R4500_00_SOLIC_RELAT_Insert2 : QueryBasis<R4500_00_SOLIC_RELAT_Insert2>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VA0851B' ,
            CURRENT DATE,
            'VA' ,
            'VA0433B' ,
            0,
            0,
            CURRENT DATE,
            CURRENT DATE,
            :V0RELA-DTVENCTO,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0RELA-NRPARCEL,
            :V0PROP-NRCERTIF,
            :V0RELA-NRTIT,
            0,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0851B' , CURRENT DATE, 'VA' , 'VA0433B' , 0, 0, CURRENT DATE, CURRENT DATE, {FieldThreatment(this.V0RELA_DTVENCTO)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0RELA_NRPARCEL)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0RELA_NRTIT)}, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RELA_DTVENCTO { get; set; }
        public string V0RELA_NRPARCEL { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RELA_NRTIT { get; set; }

        public static void Execute(R4500_00_SOLIC_RELAT_Insert2 r4500_00_SOLIC_RELAT_Insert2)
        {
            var ths = r4500_00_SOLIC_RELAT_Insert2;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4500_00_SOLIC_RELAT_Insert2 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}