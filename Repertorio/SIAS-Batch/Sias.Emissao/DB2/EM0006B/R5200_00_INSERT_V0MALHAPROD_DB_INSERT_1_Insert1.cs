using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1 : QueryBasis<R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0MALHAPROD
            VALUES (:V0MPRD-NUM-APOL ,
            :V0MPRD-CODSUBES ,
            :V0MPRD-CODCORR ,
            :V0MPRD-CODPRP ,
            :V0MPRD-CODCLB ,
            :V0MPRD-INSPETOR ,
            :V0MPRD-ISPRGI ,
            :V0MPRD-CODGTE ,
            :V0MPRD-CODSTE ,
            :V0MPRD-DIRRGI ,
            :V0MPRD-DIRCMC ,
            :V0MPRD-COD-EMP:VIND-COD-EMP,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MALHAPROD VALUES ({FieldThreatment(this.V0MPRD_NUM_APOL)} , {FieldThreatment(this.V0MPRD_CODSUBES)} , {FieldThreatment(this.V0MPRD_CODCORR)} , {FieldThreatment(this.V0MPRD_CODPRP)} , {FieldThreatment(this.V0MPRD_CODCLB)} , {FieldThreatment(this.V0MPRD_INSPETOR)} , {FieldThreatment(this.V0MPRD_ISPRGI)} , {FieldThreatment(this.V0MPRD_CODGTE)} , {FieldThreatment(this.V0MPRD_CODSTE)} , {FieldThreatment(this.V0MPRD_DIRRGI)} , {FieldThreatment(this.V0MPRD_DIRCMC)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0MPRD_COD_EMP))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0MPRD_NUM_APOL { get; set; }
        public string V0MPRD_CODSUBES { get; set; }
        public string V0MPRD_CODCORR { get; set; }
        public string V0MPRD_CODPRP { get; set; }
        public string V0MPRD_CODCLB { get; set; }
        public string V0MPRD_INSPETOR { get; set; }
        public string V0MPRD_ISPRGI { get; set; }
        public string V0MPRD_CODGTE { get; set; }
        public string V0MPRD_CODSTE { get; set; }
        public string V0MPRD_DIRRGI { get; set; }
        public string V0MPRD_DIRCMC { get; set; }
        public string V0MPRD_COD_EMP { get; set; }
        public string VIND_COD_EMP { get; set; }

        public static void Execute(R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1 r5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1)
        {
            var ths = r5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}